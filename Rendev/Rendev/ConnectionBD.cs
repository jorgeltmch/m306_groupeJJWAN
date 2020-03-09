using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


/// <summary>
/// Lien utile
/// la connection, le select, le insert, le update et le delete: https://www.c-sharpcorner.com/UploadFile/9582c9/insert-update-delete-display-data-in-mysql-using-C-Sharp/
/// </summary>


namespace Rendev
{
    class ConnectionBD
    {
        private static ConnectionBD instance;

        // connection à la basse de donnée
        private string sDatabase = "server=hibou.lab.ecinf.ch;database=rendev;port=3307;userid=rendev;password=Super2020?";

        private ConnectionBD()
        {

        }

        public static ConnectionBD getInstance()
        {
            if (instance == null)
                instance = new ConnectionBD();

            return instance;
        }

        public Dictionary<int,Dictionary<string, string>> getValues(string nomTable)
        {
            Dictionary<int, Dictionary<string,string>> dicoIdentifiant = new Dictionary<int, Dictionary<string, string>>();
            Dictionary<string, string> dicoValeurIdentrifiant = new Dictionary<string, string>();


            string myConnection = sDatabase;

            string sql = "Select * From " + nomTable;

            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            myReader.Read();


            switch (nomTable)
            {
                case "rendev.evenement":
                    for (int i = 0; i < CountIdEvent(); i++)
                    {
                        while (myReader.Read())
                        {
                            //dicoValeurIdentrifiant.Add(myReader[i],);
                        }
                        dicoIdentifiant.Add(i, dicoValeurIdentrifiant);
                    }
                    break;
                case "rendev.position":
                    for (int i = 0; i < CountIdPosition(); i++)
                    {

                    }
                    break;
                case "rendev.categorie":
                    for (int i = 0; i < CountIdCategorie(); i++)
                    {

                    }
                    break;
            }
            
            return dicoIdentifiant;
        }
        
        #region Avoir le nombre de id de chaque table
        public int CountIdEvent()
        {
            string myConnection = sDatabase;

            string sql = "Select COUNT(idEvent) From rendev.evenement";

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
            string myConnection = sDatabase;

            string sql = "Select COUNT(idEvent) From rendev.position";

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
            string myConnection = sDatabase;

            string sql = "Select COUNT(idEvent) From rendev.categorie";

            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            myReader.Read();

            return Convert.ToInt32(myReader[0].ToString());
        }
        #endregion
        #region Méthodes Insert
        public void InsertDataEvent(string nameEvent, string descriptionEvent, DateTime date, int idPosition, int idCategorie)
        {
            string myConnection = sDatabase;

            string sql = "insert into rendev.evenement(idEvent, nomEvent, descriptionEvent, dateEvent, idPosition, idCategorie) values('" + CountIdEvent() + 1 + "','" + nameEvent + "','" + descriptionEvent + "','" + date.ToString("yyyy-MM-dd") + "','" + idPosition + "','" + idCategorie + "')";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            myConn.Close();
        }

        public void InsertDataPosition(double latitude, double longitude)
        {
            string myConnection = sDatabase;

            string sql = "insert into rendev.evenement(idEvent, latitude, longitude) values('" + CountIdPosition() + 1 + "','" + latitude + "','" + longitude + "')";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            myConn.Close();
        }

        public void InsertDataCategorie(string nomCategorie)
        {
            string myConnection = sDatabase;

            string sql = "insert into rendev.evenement(idEvent, nomCategorie, imageCategorie) values('" + CountIdPosition() + 1 + "','" + nomCategorie + "','undifined.png')";

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
            string myConnection = sDatabase;

            string sql = "update rendev.evenement set nomEvent='" + nomEvent + "', descriptionEvent='" + descriptionEvent + "', dateEvent='" + date.ToString("yyyy-MM-dd") + "', idPosition='" + idPosition + "', idCategorie='" + idCategorie + "' where idEvent='" + idEvent + "'";

            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;
            myConn.Open();
            myReader = myCommand.ExecuteReader();
            myConn.Close();//Connection closed here 
        }

        public void UpdatePosition(int idPosition, int latitude, int logitude)
        {
            string myConnection = sDatabase;

            string sql = "update rendev.position set latitude='" + latitude + "', longitude='" + logitude + "' where idEvent='" + idPosition + "'";

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
            string myConnection = sDatabase;

            string sql = "delete from rendev.evenement where nomEvent='" + nomEvent + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;
            myConn.Open();
            myReader = myCommand.ExecuteReader();
            myConn.Close();
        }

        public void DeletePosition(int idPosition)
        {
            string myConnection = sDatabase;

            string sql = "delete from rendev.position where idPosition='" + idPosition + "';";
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
