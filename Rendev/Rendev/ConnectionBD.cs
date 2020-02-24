using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


/// <summary>
/// Lien utile
/// la connection et selection : https://www.youtube.com/watch?v=-xrRYzdnmBc
/// autre methode pour la selection plus update : https://dev.mysql.com/doc/dev/connector-net/8.0/html/P_MySql_Data_MySqlClient_MySqlDataAdapter_UpdateCommand.htm
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
    }
}
