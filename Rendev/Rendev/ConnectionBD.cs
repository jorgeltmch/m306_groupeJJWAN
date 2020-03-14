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

            string sql = "Select * From evenement WHERE idEvenement = "+ idEvent +"";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            myReader.Read();
            
            return myReader[typeValue].ToString();

            myConn.Close();

        }

        public string SelectChampCategory(int idCategorie, string typeValue)
        {
            string myConnection = _sDatabase;

            string sql = "Select * From categorie WHERE idCategorie = " + idCategorie + "";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            return myReader[typeValue].ToString();

            myConn.Close();

        }

        public string SelectChampPosition(int idPosition, string typeValue)
        {
            string myConnection = _sDatabase;

            string sql = "Select * From position WHERE idPosition = " + idPosition + "";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            return myReader[typeValue].ToString();

            myConn.Close();

        }
        public Dictionary<int, string> GetAllCategoriesNames()
        {
            string myConnection = _sDatabase;
            Dictionary<int, string> _returnValues = new Dictionary<int, string>();

            string sql = "SELECT idCategorie, nomCategorie FROM categorie;";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();
            
            while (myReader.Read())
            {
                _returnValues.Add(Convert.ToInt32(myReader.GetString("idCategorie")), myReader.GetString("nomCategorie"));
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
        #endregion
        #region Méthodes Insert
        public void InsertDataEvent(string nameEvent, string descriptionEvent, DateTime date, int idPosition, int idCategorie)
        {
            string myConnection = _sDatabase;

            string sql = "insert into rendevdb.evenement(nomEvenement, descriptionEvenement, dateEvenement, idPosition, idCategorie) values('" + nameEvent + "','" + descriptionEvent + "','" + date.ToString("yyyy-MM-dd") + "','" + idPosition + "','" + idCategorie + "')";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

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

        public void InsertDataCategorie(string nomCategorie)
        {
            string myConnection = _sDatabase;

            string sql = "insert into rendevdb.categorie(nomCategorie, imageCategorie) values('" + nomCategorie + "','undifined.png')";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            myConn.Close();
        }
        #endregion

        #region Méthodes Update
        public void UpdateEvent(int idEvent, string nomEvent, string descriptionEvent, DateTime date, int idPosition, int idCategorie)
        {
            string myConnection = _sDatabase;

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
