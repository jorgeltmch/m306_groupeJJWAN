/* 
 * Programme Rendev
 * Description:
 * Permet d'ajouter des evenements sur une carte et des les envoyer dans une base de donnée et de traiter ces données
 * Version 1.0
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using MySql.Data.MySqlClient;

namespace Rendev
{
    class ConnectionBD
    {
        private static ConnectionBD _instance;

        // connection à la basse de donnée
        //private string _sDatabase = "server=hibou.lab.ecinf.ch;database=rendev;port=3307;userid=rendev;password=Super2020?";

        // Constructeur de la base de la calsse
        private ConnectionBD()
        {
        }

        public static ConnectionBD getInstance()
        {
            if (_instance == null)
                _instance = new ConnectionBD();

            return _instance;
        }

        // Fonction non utiliser à voire avec nelson si on supprime ou si on garde en cas de besoin
        /*#region Avoir le nombre de id de chaque table
        public int CountIdEvent()
        {
            string myConnection = Constants.CONNECTION_STRING;

            string sql = "Select COUNT(idEvenement) From evenement";

            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            myReader.Read();

            return Convert.ToInt32(myReader[0].ToString());
        }

        public int CountIdPosition()
        {
            string myConnection = Constants.CONNECTION_STRING;

            string sql = "Select COUNT(idPosition) From position";

            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            myReader.Read();

            return Convert.ToInt32(myReader[0].ToString());
        }

        public int CountIdCategorie()
        {
            string myConnection = Constants.CONNECTION_STRING;

            string sql = "Select COUNT(idCategorie) From categorie";

            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            myReader.Read();

            return Convert.ToInt32(myReader[0].ToString());
        }
        #endregion*/

        #region Méthodes Select

        /// <summary>
        /// Retourne un Evenement de la base de donnée en fonction de l'id
        /// </summary>
        /// <param name="idEvent">Definit quel Evenement on choisie</param>
        /// <param name="typeValue">Definit quel type de valeur de l'Evenement qu'on veut</param>
        /// <returns></returns>
        public string SelectChampEvent(int idEvent, string typeValue)
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            // Try catch permet s'il y a une erreur que la requête ne se face pas
            try
            {
                // Requete Sql qu'on va utiliser
                string sql = "Select * From evenement WHERE idEvenement = " + idEvent + "";

                MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée

                MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
                MySqlDataReader myReader;

                myConn.Open(); // Ouverture de la connection

                myReader = myCommand.ExecuteReader(); // Reception des données reçue de la base de donnée

                myReader.Read(); // Lecture des données

                return myReader[typeValue].ToString();
            }
            catch (Exception)
            {
                return null;
            }


        }

        /// <summary>
        /// Retourne une Category de la base de donnée en fonction de l'id
        /// </summary>
        /// <param name="idCategorie">Definit quel Evenement on choisie</param>
        /// <param name="typeValue">Definit quel type de valeur de l'Evenement qu'on veut</param>
        /// <returns></returns>
        public string SelectChampCategory(int idCategorie, string typeValue)
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            // Try catch permet s'il y a une erreur que la requête ne se face pas
            try
            {
                // Requete Sql qu'on va utiliser
                string sql = "Select * From categorie WHERE idCategorie = " + idCategorie + "";

                MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée

                MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
                MySqlDataReader myReader;

                myConn.Open(); // Ouverture de la connection

                myReader = myCommand.ExecuteReader(); // Reception des données reçue de la base de donnée

                myReader.Read(); // Lecture des données

                return myReader[typeValue].ToString();

                myConn.Close();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retourne une Position de la base de donnée en fonction de l'id
        /// </summary>
        /// <param name="idPosition">Definit quel Evenement on choisie</param>
        /// <param name="typeValue">Definit quel type de valeur de l'Evenement qu'on veut</param>
        /// <returns></returns>
        public string SelectChampPosition(int idPosition, string typeValue)
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            // Try catch permet s'il y a une erreur que la requête ne se face pas
            try
            {
                // Requete Sql qu'on va utiliser
                string sql = "Select * From position WHERE idPosition = " + idPosition + "";

                MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée

                MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
                MySqlDataReader myReader;

                myConn.Open(); // Ouverture de la connection

                myReader = myCommand.ExecuteReader(); // Reception des données reçue de la base de donnée

                myReader.Read(); // Lecture des données

                return myReader[typeValue].ToString();

                myConn.Close();

            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// Permet d'avoir la liste de toute les Catégories
        /// </summary>
        /// <returns>List de Category</returns>
        public List<Category> GetAllCategories()
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            List<Category> _returnValues = new List<Category>(); // List de catégorie

            // Try catch permet s'il y a une erreur que la requête ne se face pas
            try
            {
                // Requete Sql qu'on va utiliser
                string sql = "SELECT idCategorie, nomCategorie FROM categorie;";

                MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée

                MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
                MySqlDataReader myReader;

                myConn.Open(); // Ouverture de la connection

                myReader = myCommand.ExecuteReader(); // Reception des données reçue de la base de donnée

                // Permet de parcourir toutes les valeurs
                while (myReader.Read())
                {
                    // Ajoute dans la liste des Catégory
                    _returnValues.Add(new Category(Convert.ToInt32(myReader.GetString("idCategorie")), myReader.GetString("nomCategorie"), Constants.EVENT_MARKER_TYPE));
                }

                return _returnValues;

                myConn.Close();
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// Permet d'avoir la liste de toute les Positions
        /// </summary>
        /// <returns>List de Position</returns>
        public List<Position> GetAllPositions()
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            List<Position> _returnValues = new List<Position>(); // List de Position

            // Try catch permet s'il y a une erreur que la requête ne se face pas
            try
            {
                // Requete Sql qu'on va utiliser
                string sql = "Select * From position;";

                MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée

                MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
                MySqlDataReader myReader;

                myConn.Open(); // Ouverture de la connection

                myReader = myCommand.ExecuteReader(); // Reception des données reçue de la base de donnée

                // Permet de parcourir toutes les valeurs
                while (myReader.Read())
                {
                    // Ajoute dans la liste des Positions
                    _returnValues.Add(new Position(Convert.ToInt32(myReader.GetString("idPosition")), new PointLatLng(myReader.GetDouble("latitude"), myReader.GetDouble("longitude"))));
                }
                return _returnValues;

                myConn.Close();
            }
            catch (Exception)
            {
                return null;
            }
        }


        // Même méthode que celle juste au dessus
        public List<PointLatLng> GetAllEventPositions()
        {
            string myConnection = Constants.CONNECTION_STRING;

            List<PointLatLng> _returnValues = new List<PointLatLng>(); // List de Position

            // Try catch permet s'il y a une erreur que la requête ne se face pas
            try
            {
                // Requete Sql qu'on va utiliser
                string sql = "SELECT latitude, longitude FROM position;";

                MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée

                MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
                MySqlDataReader myReader;

                myConn.Open(); // Ouverture de la connection

                myReader = myCommand.ExecuteReader(); // Reception des données reçue de la base de donnée

                // Permet de parcourir toutes les valeurs
                while (myReader.Read())
                {
                    // Ajoute dans la liste des 
                    _returnValues.Add(new PointLatLng(myReader.GetDouble("latitude"), myReader.GetDouble("longitude")));
                }
                return _returnValues;

                myConn.Close();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Permet d'avoir la liste de tous les Evenements et de mettre à jour les listes Position et Catégory
        /// </summary>
        /// <returns>List d'Evenement</returns>
        public List<Event> GetAllEvents()
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            List<Event> _returnValues = new List<Event>(); // List d'Evenement

            // Try catch permet s'il y a une erreur que la requête ne se face pas
            try
            {
                // Requete Sql qu'on va utiliser
                string sql = "SELECT idEvenement, nomEvenement, descriptionEvenement, dateEvenement, evenement.idPosition, latitude, longitude, evenement.idCategorie, nomCategorie, ImageCategorie FROM evenement JOIN position ON position.idPosition = evenement.idPosition JOIN categorie ON categorie.idCategorie = evenement.idCategorie";

                MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée

                MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
                MySqlDataReader myReader;

                myConn.Open(); // Ouverture de la connection

                myReader = myCommand.ExecuteReader(); // Reception des données reçue de la base de donnée

                // Permet de parcourir toutes les valeurs
                while (myReader.Read())
                {
                    // Permet de mettre à jour les données de la liste de Category
                    Category eventCategory = DataManager.GetInstance().GetCategoryByIdIfExist(myReader.GetInt32("idCategorie"));
                    if (eventCategory == null)
                    {
                        eventCategory = new Category(myReader.GetInt32("idCategorie"), myReader.GetString("nomCategorie"), Constants.EVENT_MARKER_TYPE);
                        DataManager.GetInstance().Categories.Add(eventCategory);
                    }

                    // Permet de mettre à jour les données de la liste de Position
                    Position eventPosition = DataManager.GetInstance().GetPositionByIdIfExist(myReader.GetInt32("idPosition"));
                    if (eventPosition == null)
                    {
                        eventPosition = new Position(myReader.GetInt32("idPosition"), new PointLatLng(myReader.GetDouble("latitude"), myReader.GetDouble("longitude")));
                        DataManager.GetInstance().Positions.Add(eventPosition);
                    }

                    _returnValues.Add(new Event(myReader.GetInt32("idEvenement"), myReader.GetString("nomEvenement"), eventCategory, myReader.GetString("descriptionEvenement"), myReader.GetDateTime("dateEvenement"), eventPosition));
                }

                return _returnValues;

                myConn.Close();
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Méthodes Insert
        /// <summary>
        /// Permet d'ajouter un evenement dans la base de donnée
        /// </summary>
        /// <param name="nameEvent">Nom de l'Evenement à ajouter</param>
        /// <param name="descriptionEvent">Description de l'Evenement à ajouter</param>
        /// <param name="date">Date de l'Evenement à ajouter</param>
        /// <param name="idPosition">L'id de la Position de l'Evenement à ajouter</param>
        /// <param name="idCategorie">L'id de la Categorie de l'Evenement à ajouter</param>
        /// <returns>L'id de l'Evenement ajouter</returns>
        public long InsertDataEvent(string nameEvent, string descriptionEvent, DateTime date, int idPosition, int idCategorie)
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            // Requete Sql qu'on va utiliser
            string sql = "insert into rendevdb.evenement(nomEvenement, descriptionEvenement, dateEvenement, idPosition, idCategorie) values('" + nameEvent + "','" + descriptionEvent + "','" + date.ToString("yyyy-MM-dd") + "','" + idPosition + "','" + idCategorie + "')";

            MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée

            MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
            MySqlDataReader myReader;

            myConn.Open(); // Ouverture de la connection

            myReader = myCommand.ExecuteReader(); // Envoyer les données à la base de donnée

            return myCommand.LastInsertedId;
            myConn.Close();

        }

        /// <summary>
        /// Permet d'ajouter une position dans la base de donnée
        /// </summary>
        /// <param name="latitude">Latitude de la Position à ajouter</param>
        /// <param name="longitude">Longitude de la Position à ajouter</param>
        /// <returns>L'id de la Position ajouter</returns>
        public long InsertDataPosition(double latitude, double longitude)
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            // Requete Sql qu'on va utiliser
            string sql = "insert into rendevdb.position(latitude, longitude) values('" + latitude + "','" + longitude + "')";

            MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée

            MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
            MySqlDataReader myReader;

            myConn.Open(); // Ouverture de la connection

            myReader = myCommand.ExecuteReader(); // Envoyer les données à la base de donnée

            return myCommand.LastInsertedId;
            myConn.Close();
        }

        /// <summary>
        /// Permet d'ajouter une categorie dans la base de donnée
        /// </summary>
        /// <param name="nomCategorie">Nom de la Categorie à ajouter</param>
        /// <returns>L'id de la Categorie ajouter</returns>
        public long InsertDataCategorie(string nomCategorie)
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            // Requete Sql qu'on va utiliser
            string sql = "insert into rendevdb.categorie(nomCategorie, imageCategorie) values('" + nomCategorie + "','undifined.png')";

            MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée

            MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
            MySqlDataReader myReader;

            myConn.Open(); // Ouverture de la connection

            myReader = myCommand.ExecuteReader(); // Envoyer les données à la base de donnée

            return myCommand.LastInsertedId;

            myConn.Close();
        }
        #endregion

        #region Méthodes Update
        /// <summary>
        /// Permet de mettre à jour un evenement dans la base de donnée
        /// </summary>
        /// <param name="idEvent">L'id de l'Evenement à modifier</param>
        /// <param name="nomEvent">Nom de l'Evenement à modifier</param>
        /// <param name="descriptionEvent">Description de l'Evenement à modifier</param>
        /// <param name="date">Date de l'Evenement à modifier</param>
        /// <param name="position">Position de l'Evenement à modifier</param>
        /// <param name="categorie">Categorie de l'Evenement à modifier</param>
        public void UpdateEvent(int idEvent, string nomEvent, string descriptionEvent, DateTime date, Position position, Category categorie)
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            long idCategorie = categorie.Id; // Catégorie de l'Evenement dans la base de donnée
            string idcat = SelectChampCategory(categorie.Id, "idCategorie"); // Catégorie selectionner par l'utilisateur

            // Permet de verifier si la catégorie à chnager
            if (idcat != categorie.Id.ToString())
            {
                idCategorie = InsertDataCategorie(categorie.Name);
            }

            long idPosition = InsertDataPosition((float)position.PointLatLng.Lat, (float)position.PointLatLng.Lng); // Insertion d'une nouvelle position

            // Requete Sql qu'on va utiliser
            string sql = "update rendevdb.evenement set nomEvenement='" + nomEvent + "', descriptionEvenement='" + descriptionEvent + "', dateEvenement='" + date.ToString("yyyy-MM-dd") + "', idPosition='" + idPosition + "', idCategorie='" + idCategorie + "' where idEvenement='" + idEvent + "'";

            MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée
            MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
            MySqlDataReader myReader;

            myConn.Open(); // Ouverture de la connection

            myReader = myCommand.ExecuteReader(); // Envoyer les données à la base de donnée

            myConn.Close();//Connection closed here 
        }

        /// <summary>
        /// Permet de mettre à jour une Position dans la base de donnée
        /// </summary>
        /// <param name="idPosition">L'id de la Position à modifier</param>
        /// <param name="latitude">Latitude de la Position à modifier</param>
        /// <param name="logitude">Longitude de la Position à modifier</param>
        public void UpdatePosition(int idPosition, int latitude, int logitude)
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            // Requete Sql qu'on va utiliser
            string sql = "update rendevdb.position set latitude='" + latitude + "', longitude='" + logitude + "' where idEvenement='" + idPosition + "'";

            MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée
            MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
            MySqlDataReader myReader;

            myConn.Open(); // Ouverture de la connection

            myReader = myCommand.ExecuteReader(); // Envoyer les données à la base de donnée

            myConn.Close();//Connection closed here 
        }
        #endregion

        #region Methodes Delete
        /// <summary>
        /// Permet de suprimer un Evenement de la base de donnée
        /// </summary>
        /// <param name="nomEvent">Nom de l'Evenement à suprimer</param>
        public void DeleteEvenement(string nomEvent)
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            // Requete Sql qu'on va utiliser
            string sql = "delete from rendevdb.evenement where nomEvenement='" + nomEvent + "';";

            MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée
            MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
            MySqlDataReader myReader;

            myConn.Open(); // Ouverture de la connection

            myReader = myCommand.ExecuteReader(); // Envoyer les données à la base de donnée

            myConn.Close();//Connection closed here 
        }

        /// <summary>
        /// Permet de suprimer une Position de la base de donnée
        /// </summary>
        /// <param name="idPosition">Id de la Position à suprimer</param>
        public void DeletePosition(int idPosition)
        {
            string myConnection = Constants.CONNECTION_STRING; // Les données de connection à la base

            // Requete Sql qu'on va utiliser
            string sql = "delete from rendevdb.position where idPosition='" + idPosition + "';";

            MySqlConnection myConn = new MySqlConnection(myConnection); // Creation de la connection à la base de donnée
            MySqlCommand myCommand = new MySqlCommand(sql, myConn); // Initialisation de la requete sql
            MySqlDataReader myReader;

            myConn.Open(); // Ouverture de la connection

            myReader = myCommand.ExecuteReader(); // Envoyer les données à la base de donnée

            myConn.Close();//Connection closed here 
        }
        #endregion
    }
}
