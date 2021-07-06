using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

        void Finder(string fail, string word)
        {
            string stroka = File.ReadAllText(fail);
            //Console.WriteLine(stroka);
            string[] strokaArray = stroka.Split(new char[] { '\n', '\r', ',', ' ','.','!','-','?' },
         StringSplitOptions.RemoveEmptyEntries) ;

            var groups = strokaArray.GroupBy(n => n); 
            foreach (var item in groups)
            {
                if (item.Key == word)
                {
                    //Console.WriteLine(item.Count());
                    Console.WriteLine("Слово {0} встречается {1} раза.", word, item.Count());
                }
             
            }

        }


       
        static void Main()
        {

            Program s = new Program();
            string fail;            
            fail = @"text.txt";
            string word = "killed";
            s.Finder(fail, word);

        }
    }
}
