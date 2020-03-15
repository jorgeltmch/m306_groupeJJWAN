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
                _categories.AddRange(ConnectionBD.getInstance().GetAllCategories());
                _categories = _categories.GroupBy(c => c.Id).Select(g => g.First()).ToList();
               // _categories = _categories.Distinct().ToList();
                return _categories;
            }
            set => _categories = value;
        }
        public List<Position> Positions
        {
            get
            {
                _positions.AddRange(ConnectionBD.getInstance().GetAllPositions());
                _positions = _positions.GroupBy(p => p.Id).Select(g => g.First()).ToList();
                return _positions;
            }
            set => _positions = value;
        }
        public List<Event> Events
        {
            get
            {
                _events.AddRange(ConnectionBD.getInstance().GetAllEvents());
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
        public static DataManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataManager();
            }
            return _instance;
        }

        public Category GetCategoryByIdIfExist(int paramId)
        {
            return _categories.Find(category => category.Id == paramId);
        }
        public Position GetPositionByIdIfExist(int paramId)
        {
            return _positions.Find(position => position.Id == paramId);
        }
        public List<PointLatLng> GetEventsPosition()
        {
            List<PointLatLng> result = new List<PointLatLng>();
            Events.ForEach(e => result.Add(e.Position));
            return result;
        }
        public Event GetEventByPosition(PointLatLng paramPosition)
        {
            return Events.Find(e => e.EventPosition.PointLatLng == paramPosition);
        }
        public void RemoveEvent(string paramNom)
        {
            ConnectionBD.getInstance().DeleteEvenement(paramNom);
            Events.RemoveAll(e => e.Name == paramNom);
        }
        public void UpdateEvent(int paramId, string paramNewNom, string paramNewDescription, DateTime parmNewDate, Position paramNewPosition, Category paramNewCategorie)
        {
            Events.RemoveAll(e => e.Id == paramId);
            ConnectionBD.getInstance().UpdateEvent(paramId, paramNewNom, paramNewDescription, parmNewDate, paramNewPosition, paramNewCategorie);
            _events.AddRange(ConnectionBD.getInstance().GetAllEvents());
            _events = _events.GroupBy(e => e.Id).Select(g => g.First()).ToList();
        }
        public long AddDataPosition(double latitude, double longitude)
        {
            ConnectionBD myConnec = ConnectionBD.getInstance();
            int id = Convert.ToInt32(myConnec.InsertDataPosition(latitude, longitude));
            Positions.Add(new Position(id, new PointLatLng(latitude, longitude)));
            return id;
        }
        public long AddDataEvent(string nameEvent, string descriptionEvent, DateTime date, int idPosition, int idCategorie)
        {
            ConnectionBD myConnec = ConnectionBD.getInstance();
            int id = Convert.ToInt32(myConnec.InsertDataEvent(nameEvent, descriptionEvent, date, idPosition, idCategorie));
            Events.Add(new Event(id, nameEvent, GetCategoryByIdIfExist(idCategorie), descriptionEvent, date, GetPositionByIdIfExist(idPosition)));
            return id;
        }

    }
}
