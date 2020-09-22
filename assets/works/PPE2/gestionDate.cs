using System;

namespace Mission2
{
    public class gestionDate
    {
        public static string getMoisPrecedent()
        {
            DateTime reponse = DateTime.Now.AddMonths(-1);
            return reponse.ToString("MM");
        }

        public static string getMoisPrecedent(DateTime date)
        {
            DateTime reponse = date.AddMonths(-1);
            return reponse.ToString("MM");
        }

        
        public static string getMoisSuivant()
        {
            DateTime reponse = DateTime.Now.AddMonths(1);
            return reponse.ToString("MM");
        }

        public static string getMoisSuivant(DateTime date)
        {
            DateTime reponse = date.AddMonths(1);
            return reponse.ToString("MM");
        }

        public static Boolean entre(int date1, int date2){
            DateTime actu = DateTime.Now;
            if(date1==date2){return actu.Day == date1;}
            else if(date1<date2){return actu.Day>=date1 && actu.Day<=date2;}
            else{return actu.Day>=date2 && actu.Day<=date1;}
        }

        public static Boolean entre(int date1, int date2,DateTime date){
            DateTime actu = date;
            if(date1==date2){return actu.Day == date1;}
            else if(date1<date2){return actu.Day>=date1 && actu.Day<=date2;}
            else{return actu.Day>=date2 && actu.Day<=date1;}
        }
    }
}