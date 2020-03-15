using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using MySql.Data.MySqlClient;


/// <summary>
/// Lien utile
/// la connection, le select, le insert, le update et le delete: https://www.c-sharpcorner.com/UploadFile/9582c9/insert-update-delete-display-data-in-mysql-using-C-Sharp/
/// </summary>


namespace Rendev
{
    class ConnectionBD
    {
        private static ConnectionBD _instance;

        // connection à la basse de donnée
        //private string _sDatabase = "server=hibou.lab.ecinf.ch;database=rendev;port=3307;userid=rendev;password=Super2020?";
        private string _sDatabase;

        private ConnectionBD()
        {
            _sDatabase = Constants.CONNECTION_STRING;
        }

        public static ConnectionBD getInstance()
        {
            if (_instance == null)
                _instance = new ConnectionBD();

            return _instance;
        }

        #region Avoir le nombre de id de chaque table
        public int CountIdEvent()
        {
            string myConnection = _sDatabase;

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
            string myConnection = _sDatabase;

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
            string myConnection = _sDatabase;

            string sql = "Select COUNT(idCategorie) From categorie";

            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            myReader.Read();

            return Convert.ToInt32(myReader[0].ToString());
        }
        #endregion

        #region Méthodes Select
        public string SelectChampEvent(int idEvent, string typeValue)
        {
            string myConnection = _sDatabase;
            try
            {
                string sql = "Select * From evenement WHERE idEvenement = " + idEvent + "";

                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand myCommand = new MySqlCommand(sql, myConn);
                MySqlDataReader myReader;

                myConn.Open();

                myReader = myCommand.ExecuteReader();

                myReader.Read();

                return myReader[typeValue].ToString();

                myConn.Close();
            }
            catch (Exception)
            {
                return null;
            }


        }

        public string SelectChampCategory(int idCategorie, string typeValue)
        {
            string myConnection = _sDatabase;

            try
            {
                string sql = "Select * From categorie WHERE idCategorie = " + idCategorie + "";

                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand myCommand = new MySqlCommand(sql, myConn);
                MySqlDataReader myReader;

                myConn.Open();

                myReader = myCommand.ExecuteReader();
                myReader.Read();

                return myReader[typeValue].ToString();

                myConn.Close();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string SelectChampPosition(int idPosition, string typeValue)
        {
            string myConnection = _sDatabase;

            try
            {
                string sql = "Select * From position WHERE idPosition = " + idPosition + "";

                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand myCommand = new MySqlCommand(sql, myConn);
                MySqlDataReader myReader;

                myConn.Open();

                myReader = myCommand.ExecuteReader();
                myReader.Read();

                return myReader[typeValue].ToString();

                myConn.Close();

            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<Category> GetAllCategories()
        {
            string myConnection = _sDatabase;
            List<Category> _returnValues = new List<Category>();

            string sql = "SELECT idCategorie, nomCategorie FROM categorie;";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                _returnValues.Add(new Category(Convert.ToInt32(myReader.GetString("idCategorie")), myReader.GetString("nomCategorie"), Constants.EVENT_MARKER_TYPE));
            }
            return _returnValues;

            myConn.Close();
        }
        public List<Position> GetAllPositions()
        {
            string myConnection = _sDatabase;
            List<Position> _returnValues = new List<Position>();

            string sql = "Select * From position;";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                _returnValues.Add(new Position(Convert.ToInt32(myReader.GetString("idPosition")), new PointLatLng(myReader.GetDouble("latitude"), myReader.GetDouble("longitude"))));
            }
            return _returnValues;

            myConn.Close();
        }
        public List<PointLatLng> GetAllEventPositions()
        {
            string myConnection = _sDatabase;
            List<PointLatLng> _returnValues = new List<PointLatLng>();

            string sql = "SELECT latitude, longitude FROM position;";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                _returnValues.Add(new PointLatLng(myReader.GetDouble("latitude"), myReader.GetDouble("longitude")));
            }
            return _returnValues;

            myConn.Close();
        }
        public List<Event> GetAllEvents()
        {
            string myConnection = _sDatabase;
            List<Event> _returnValues = new List<Event>();

            string sql = "SELECT idEvenement, nomEvenement, descriptionEvenement, dateEvenement, evenement.idPosition, latitude, longitude, evenement.idCategorie, nomCategorie, ImageCategorie FROM evenement JOIN position ON position.idPosition = evenement.idPosition JOIN categorie ON categorie.idCategorie = evenement.idCategorie";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                Category eventCategory = DataManager.GetInstance().GetCategoryByIdIfExist(myReader.GetInt32("idCategorie"));
                if (eventCategory == null)
                {
                    eventCategory = new Category(myReader.GetInt32("idCategorie"), myReader.GetString("nomCategorie"), Constants.EVENT_MARKER_TYPE);
                    DataManager.GetInstance().Categories.Add(eventCategory);
                }
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
        #endregion
        #region Méthodes Insert
        public long InsertDataEvent(string nameEvent, string descriptionEvent, DateTime date, int idPosition, int idCategorie)
        {
            string myConnection = _sDatabase;

            string sql = "insert into rendevdb.evenement(nomEvenement, descriptionEvenement, dateEvenement, idPosition, idCategorie) values('" + nameEvent + "','" + descriptionEvent + "','" + date.ToString("yyyy-MM-dd") + "','" + idPosition + "','" + idCategorie + "')";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            return myCommand.LastInsertedId;
            myConn.Close();
        }

        public long InsertDataPosition(double latitude, double longitude)
        {
            string myConnection = _sDatabase;

            string sql = "insert into rendevdb.position(latitude, longitude) values('" + latitude + "','" + longitude + "')";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            return myCommand.LastInsertedId;
            myConn.Close();
        }

        public long InsertDataCategorie(string nomCategorie)
        {
            string myConnection = _sDatabase;

            string sql = "insert into rendevdb.categorie(nomCategorie, imageCategorie) values('" + nomCategorie + "','undifined.png')";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();
            return myCommand.LastInsertedId;

            myConn.Close();
        }
        #endregion

        #region Méthodes Update
        public void UpdateEvent(int idEvent, string nomEvent, string descriptionEvent, DateTime date, Position position, Category categorie)
        {
            string myConnection = _sDatabase;

            long idCategorie = categorie.Id;
            string idcat = SelectChampCategory(categorie.Id, "idCategorie");
            if (idcat != categorie.Id.ToString())
            {
                idCategorie = InsertDataCategorie(categorie.Name);
            }
            long idPosition = InsertDataPosition(position.PointLatLng.Lat, position.PointLatLng.Lng);

            string sql = "update rendevdb.evenement set nomEvenement='" + nomEvent + "', descriptionEvenement='" + descriptionEvent + "', dateEvenement='" + date.ToString("yyyy-MM-dd") + "', idPosition='" + idPosition + "', idCategorie='" + idCategorie + "' where idEvenement='" + idEvent + "'";

            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;
            myConn.Open();
            myReader = myCommand.ExecuteReader();
            myConn.Close();//Connection closed here 
        }

        public void UpdatePosition(int idPosition, int latitude, int logitude)
        {
            string myConnection = _sDatabase;

            string sql = "update rendevdb.position set latitude='" + latitude + "', longitude='" + logitude + "' where idEvenement='" + idPosition + "'";

            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;
            myConn.Open();
            myReader = myCommand.ExecuteReader();
            myConn.Close();//Connection closed here 
        }
        #endregion

        #region Methodes Delete
        public void DeleteEvenement(string nomEvent)
        {
            string myConnection = _sDatabase;

            string sql = "delete from rendevdb.evenement where nomEvenement='" + nomEvent + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;
            myConn.Open();
            myReader = myCommand.ExecuteReader();
            myConn.Close();
        }

        public void DeletePosition(int idPosition)
        {
            string myConnection = _sDatabase;

            string sql = "delete from rendevdb.position where idPosition='" + idPosition + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;
            myConn.Open();
            myReader = myCommand.ExecuteReader();
            myConn.Close();
        }
        #endregion
    }
}
