using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendev
{
    class DataManager
    {
        private List<Category> _categories;
        private List<Position> _positions;
        private List<Event> _events;
        private static DataManager _instance;

        public List<Category> Categories
        {
            get
            {
                _categories.AddRange(ConnectionDB.getInstance().GetAllCategories());
                _categories = _categories.GroupBy(c => c.Id).Select(g => g.First()).ToList();
                return _categories;
            }
            set => _categories = value;
        }
        public List<Position> Positions
        {
            get
            {
                _positions.AddRange(ConnectionDB.getInstance().GetAllPositions());
                _positions = _positions.GroupBy(p => p.Id).Select(g => g.First()).ToList();
                return _positions;
            }
            set => _positions = value;
        }
        public List<Event> Events
        {
            get
            {
                _events.AddRange(ConnectionDB.getInstance().GetAllEvents());
                _events = _events.GroupBy(e => e.Id).Select(g => g.First()).ToList();
                return _events;
            }
            set => _events = value;
        }

        private DataManager()
        {
            _categories = new List<Category>();
            _positions = new List<Position>();
            _events = new List<Event>();
        }
        /// <summary>
        /// Instancie la classe si elle ne l'est pas encore
        /// </summary>
        /// <returns>Instance courante de la classe</returns>
        public static DataManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataManager();
            }
            return _instance;
        }

        /// <summary>
        /// Cherche dans la liste de catégorie pour l'id envoyé en paramètre
        /// </summary>
        /// <param name="paramId"></param>
        /// <returns>La catégorie trouvé et null dans le contraire</returns>
        public Category GetCategoryByIdIfExist(int paramId)
        {
            try
            {
                return _categories.Find(category => category.Id == paramId);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
        /// <summary>
        /// Cherche dans la liste de position pour l'id envoyé en paramètre
        /// </summary>
        /// <param name="paramId"></param>
        /// <returns>La position trouvé et null dans le contraire</returns>
        public Position GetPositionByIdIfExist(int paramId)
        {
            try
            {
                return _positions.Find(position => position.Id == paramId);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
        /// <summary>
        /// retourne la position de tous les événements enregistrés sous la forme d’une liste de point latitude/longitude
        /// </summary>
        /// <returns>Liste des coordonnées des points</returns>
        public List<PointLatLng> GetEventsPosition()
        {
            List<PointLatLng> result = new List<PointLatLng>();
            Events.ForEach(e => result.Add(e.Position));
            return result;
        }
        /// <summary>
        /// Cherche dans la liste d'évenement pour un evenement à la position envoyé en paramètre
        /// </summary>
        /// <param name="paramId"></param>
        /// <returns>L'evenement trouvé et null dans le contraire</returns>
        public Event GetEventByPosition(PointLatLng paramPosition)
        {
            try
            {
                return Events.Find(e => e.EventPosition.PointLatLng == paramPosition);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
        /// <summary>
        /// Supprime un événement qui correspond au nom donné en paramètre
        /// </summary>
        /// <param name="paramNom"></param>
        public void RemoveEvent(string paramNom)
        {
            ConnectionDB.getInstance().DeleteEvenement(paramNom);
            Events.RemoveAll(e => e.Name == paramNom);
        }
        /// <summary>
        /// Méthode publique qui prend en paramètre l’id de l'événement à modifier et les nouvelles valeurs.
        /// </summary>
        /// <param name="paramId"></param>
        /// <param name="paramNewNom"></param>
        /// <param name="paramNewDescription"></param>
        /// <param name="parmNewDate"></param>
        /// <param name="paramNewPosition"></param>
        /// <param name="paramNewCategorie"></param>
        public void UpdateEvent(int paramId, string paramNewNom, string paramNewDescription, DateTime parmNewDate, Position paramNewPosition, Category paramNewCategorie)
        {
            Events.RemoveAll(e => e.Id == paramId);
            ConnectionDB.getInstance().UpdateEvent(paramId, paramNewNom, paramNewDescription, parmNewDate, paramNewPosition, paramNewCategorie);
            _events.AddRange(ConnectionDB.getInstance().GetAllEvents());
            _events = _events.GroupBy(e => e.Id).Select(g => g.First()).ToList(); // On enlève les doublons...
        }
        /// <summary>
        /// Ajoute une position et retourne son id
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public long AddDataPosition(double latitude, double longitude)
        {
            ConnectionDB myConnec = ConnectionDB.getInstance();
            int id = Convert.ToInt32(myConnec.InsertDataPosition(latitude, longitude));
            Positions.Add(new Position(id, new PointLatLng(latitude, longitude)));
            return id;
        }
        /// <summary>
        /// Ajoute un événement et retourne son id
        /// </summary>
        /// <param name="nameEvent"></param>
        /// <param name="descriptionEvent"></param>
        /// <param name="date"></param>
        /// <param name="idPosition"></param>
        /// <param name="idCategorie"></param>
        /// <returns></returns>
        public long AddDataEvent(string nameEvent, string descriptionEvent, DateTime date, int idPosition, int idCategorie)
        {
            ConnectionDB myConnec = ConnectionDB.getInstance();
            int id = Convert.ToInt32(myConnec.InsertDataEvent(nameEvent, descriptionEvent, date, idPosition, idCategorie));
            Events.Add(new Event(id, nameEvent, GetCategoryByIdIfExist(idCategorie), descriptionEvent, date, GetPositionByIdIfExist(idPosition)));
            return id;
        }
        /// <summary>
        /// Ajoute une catégorie et retourne son id
        /// </summary>
        /// <param name="nameCategory"></param>
        /// <returns></returns>
        public long AddDataCategory(string nameCategory)
        {
            ConnectionDB myConnec = ConnectionDB.getInstance();
            int id = Convert.ToInt32(myConnec.InsertDataCategorie(nameCategory));
            Categories.Add(new Category(id, nameCategory, Constants.EVENT_MARKER_TYPE));
            return id;
        }
    }
}
