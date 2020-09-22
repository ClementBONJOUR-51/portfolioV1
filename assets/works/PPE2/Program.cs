using System;
using System.Collections.Generic;

namespace Mission2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;

            Connection maConnection = Connection.getPdoGsb();

            /*if (today.ToString("dd").Equals("01"))
            {
                var requete = "UPDATE fichefrais SET idetat = 'CL' WHERE mois = '" + today.ToString("yyyy") + gestionDate.getMoisPrecedent() + "' AND idetat = 'CR' ";
                maConnection.sendNonQuery(requete);
            }

            if (today.ToString("dd").Equals("20"))
            {
                var requete = "UPDATE fichefrais SET idetat = 'RB' WHERE mois = '" + today.ToString("yyyy") + gestionDate.getMoisPrecedent() + "' ";
                maConnection.sendNonQuery(requete);
            }*/
            testSQL();
        }

        static public void testSQL()
        {
            Connection maConnection = Connection.getPdoGsb();
            var stm = "SELECT idvisiteur, mois, idetat FROM fichefrais";
            List<List<string>> reponse = maConnection.sendQuery(stm);

            foreach (List<string> ligne in reponse)
            {
                foreach (string val in ligne)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

/* dotnet run */
