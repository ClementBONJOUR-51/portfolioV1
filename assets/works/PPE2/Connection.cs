using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Mission2
{

    public class Connection
    {

        private static string serveur = "localhost";
        private static string bdd = "gsb_frais";
        private static string user = "root";
        private static string mdp = "";
        private static MySqlConnection monPdo;
        private static Connection monPdoGsb = null;

        /**
         * Constructeur privé, crée l'instance de PDO qui sera sollicitée
         * pour toutes les méthodes de la classe
         */
        private Connection()
        {
            string _ConnectionString = "Database=" + Connection.bdd + ";Data Source=" + Connection.serveur + ";User Id=" + Connection.user + ";Password=" + Connection.mdp;
            Connection.monPdo = new MySqlConnection(); //nouvelle connection à MySQL
            Connection.monPdo.ConnectionString = _ConnectionString;

            Connection.monPdo.Open();
            var cmd = new MySqlCommand("SET CHARACTER SET utf8", Connection.monPdo);
            cmd.ExecuteReader();
            Connection.monPdo.Close();
        }



        /**
         * Méthode destructeur
         */
        private void destruct()
        {
            Connection.monPdo.Close();
            Connection.monPdo = null;
            Connection.monPdoGsb = null;
        }

        /**
         * Fonction statique qui crée l'unique instance de la classe
         *
         * @return l'unique objet de la classe Connection
         */
        public static Connection getPdoGsb()
        {
            if (Connection.monPdoGsb == null)
            {
                Connection.monPdoGsb = new Connection();
            }
            return Connection.monPdoGsb;
        }

        public List<List<string>> sendQuery(string req)
        {
            monPdo.Open();
            var cmd = new MySqlCommand(req, monPdo);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<List<string>> tableau = new List<List<string>>();

            while (reader.Read())
            {
                List<string> ligne = new List<string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ligne.Add(reader[i].ToString());
                }
                tableau.Add(ligne);
            }

            reader.Close();
            monPdo.Close();
            return tableau;

        }

        public void sendNonQuery(String req)
        {
            monPdo.Open();
            var cmd = new MySqlCommand(req, monPdo);
            cmd.ExecuteNonQuery();

            monPdo.Close();
        }


    }
}
