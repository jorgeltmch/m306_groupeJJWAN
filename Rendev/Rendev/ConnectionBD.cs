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

        public string getValues()
        {
            string myConnection = sDatabase;

            MySqlConnection myConn = new MySqlConnection(myConnection);
            myConn.Open();

            MySqlCommand sql = new MySqlCommand("Select nomEvent From evenement", myConn);
            MySqlDataReader dr;
            dr = sql.ExecuteReader();

            dr.Read();

            return dr["nomEvent"].ToString();
        }

        public void changeValues()
        {
            string myConnection = sDatabase;

            MySqlConnection myConn = new MySqlConnection(myConnection);
            myConn.Open();

            MySqlCommand sql = new MySqlCommand("Update evenement set nomEvent=Conf23 where idEvent=1", myConn);

            MySqlDataAdapter mda = new MySqlDataAdapter();
            mda.UpdateCommand = sql;
        }

        public void InsertDataEvent(string nameEvent, string descriptionEvent, DateTime date, int idPosition, int idCategorie)
        {
            string myConnection = sDatabase;


            // Valeur pour faire les test
            //int idEvent = 3;
            //string nom = "Testage";
            //string description = "testage est present";
            //DateTime date = new DateTime(2020, 03, 02);
            //int position = 1;
            //int categorie = 1;

            string sql = "insert into rendev.evenement(idEvent, nomEvent, descriptionEvent, dateEvent, idPosition, idCategorie) values('" + CountIdEvent()+1 + "','"+ nameEvent + "','"+ descriptionEvent + "','"+date.ToString("yyyy-MM-dd")+"','"+ idPosition + "','"+ idCategorie + "')";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;

            myConn.Open();

            myReader = myCommand.ExecuteReader();

            myConn.Close();
        }

        public int CountIdEvent()
        {
            string myConnection = sDatabase;

            MySqlConnection myConn = new MySqlConnection(myConnection);
            myConn.Open();

            MySqlCommand sql = new MySqlCommand("Select COUNT(idEvent) From evenement", myConn);
            MySqlDataReader dr;
            dr = sql.ExecuteReader();

            dr.Read();

            return (int)dr["COUNT(idEvent)"];
        }
        

        public void Update()
        {
            string myConnection = sDatabase;


            int idEvent = 4;
            string nom = "ça marche ?";
            //string description = "testage est present";
            //DateTime date = new DateTime(2020, 03, 02);
            //int position = 1;
            //int categorie = 1;

            string sql = "update rendev.evenement set nomEvent='"+nom+"' where idEvent='"+idEvent+"'";
            
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;
            myConn.Open();
            myReader = myCommand.ExecuteReader();
            myConn.Close();//Connection closed here 
        }

        public void Delete()
        {
            string myConnection = sDatabase;
            
            int idEvent = 4;

            string sql = "delete from rendev.evenement where idEvent='" + idEvent + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(sql, myConn);
            MySqlDataReader myReader;
            myConn.Open();
            myReader = myCommand.ExecuteReader();
            myConn.Close();
        }
    }
}
