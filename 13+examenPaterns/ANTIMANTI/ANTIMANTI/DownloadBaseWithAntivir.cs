using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace ANTIMANTI
{
    class DownloadBaseAntivir
    {


        public string Date { get; private set; }
        public static string text = "Checking the database for updates ";

        //возвращает UpdateBase.instance
        private DownloadBaseAntivir()
        {
            Thread.Sleep(2000);
            // void update() { Console.WriteLine($"Downloud data"); }
            Console.WriteLine($"Base updated  {DateTime.Now}");            
            Date = DateTime.Now.TimeOfDay.ToString();


        }

        //заходит сюда
        public static DownloadBaseAntivir GetInstance()
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Your data base is old. Updated....  ");
           
            return UpdateBase.instance;
        }

        private class UpdateBase
        {
            static UpdateBase() { }
           
            internal static readonly DownloadBaseAntivir instance = new DownloadBaseAntivir();
        }


    }
}
