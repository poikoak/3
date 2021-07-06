using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static string first ;
        static string second ;
        static string third ;
        static string last;

        static void _first(string line)
        {

            try
            {
                MatchCollection m = Regex.Matches(line, @"\d+\/+\d");
                
                    if (first != line)
                    {
                        first = null;
                    }
                
                foreach (Match match in m)
                {
                    
                        if (match != null)
                        {

                        string[] digits = Regex.Split(match.Value, @"\D+");
                        double sum = 0;
                        double x = 0;
                        double number = 0;
                        foreach (string value in digits)
                        {

                            if (double.TryParse(value, out number))

                            {

                                if (sum == 0)
                                {

                                    sum += number;

                                }

                            }

                        }
                        x = sum / number;
                        string some = x.ToString();
                        first = Regex.Replace(line, @"\w*\d+\/+\d\w*", some);
                        // Console.WriteLine(Regex.Replace(first, @"\w*\d+\/+\d\w*", some));
                        // File.WriteAllText(@"2.txt", Regex.Replace(line, @"\d+\/+\d", some));
                        /*FileStream fs = new FileStream(@"2.txt", FileMode.Create, FileAccess.Write);
                        BinaryWriter bw = new BinaryWriter(fs, Encoding.Default);
                        bw.Write(Regex.Replace(line, @"\d+\/+\d", some));*/
                       

                    }
                    
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void _second(string line,  string first)
        {

            try
            {
                if (first != null)
                {
                    MatchCollection a = Regex.Matches(first, @"\d+\++\d");
                    if (second != first)
                    {
                        second = null;
                    }
                    foreach (Match mat in a)
                    {

                        string[] digits = Regex.Split(mat.Value, @"\D+");
                        double sum = 0;
                        double x = 0;
                        double number = 0;
                        foreach (string value in digits)
                        {

                            if (double.TryParse(value, out number))

                            {

                                if (sum == 0)
                                {

                                    sum += number;


                                }

                            }

                        }
                        x = sum + number;
                        string some = x.ToString();
                        second = Regex.Replace(first, @"\w*\d+\++\d\w*", some);
                         File.AppendAllText(@"2.txt", second);
                        // FileStream fs = new FileStream(@"2.txt", FileMode.Create, FileAccess.Write);
                        // BinaryWriter bw = new BinaryWriter(fs, Encoding.Default);
                        // bw.Write(Regex.Replace(line, @"\d+\++\d", some));
                    }
                }
                if (first == null)
                {
                    
                     
                    MatchCollection a = Regex.Matches(line, @"\d+\++\d");
                    if (second != line)
                    {
                        second = null;
                    }
                    foreach (Match mat in a)
                    {

                        string[] digits = Regex.Split(mat.Value, @"\D+");
                        double sum = 0;
                        double x = 0;
                        double number = 0;
                        foreach (string value in digits)
                        {

                            if (double.TryParse(value, out number))

                            {

                                if (sum == 0)
                                {

                                    sum += number;


                                }

                            }

                        }
                        x = sum + number;
                        string some = x.ToString();
                        second = Regex.Replace(line, @"\w*\d+\++\d\w*", some);
                      //  File.AppendAllText(@"2.txt", second);
                        // FileStream fs = new FileStream(@"2.txt", FileMode.Create, FileAccess.Write);
                        // BinaryWriter bw = new BinaryWriter(fs, Encoding.Default);
                        // bw.Write(Regex.Replace(line, @"\d+\++\d", some));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void _third(string line, string second)
        {


            try
            {
                if (second != null)
                {
                    MatchCollection f = Regex.Matches(second, @"\d+\-+\d");
                    if (third != second)
                    {
                        third = null;
                    }
                    foreach (Match matc in f)
                    {

                        string[] digits = Regex.Split(matc.Value, @"\D+");
                        double sum = 0;
                        double x = 0;
                        double number = 0;
                        foreach (string value in digits)
                        {

                            if (double.TryParse(value, out number))

                            {

                                if (sum == 0)
                                {

                                    sum += number;

                                }

                            }

                        }
                        x = sum - number;
                        string some = x.ToString();
                        third = Regex.Replace(second, @"\w*\d+\-+\d\w*", some);
                       // File.AppendAllText(@"2.txt", third);
                    }
                }

                if (second == null)
                {
                    MatchCollection f = Regex.Matches(line, @"\d+\-+\d");
                    if (third != line)
                    {
                        third = null;
                    }
                    foreach (Match matc in f)
                    {

                        string[] digits = Regex.Split(matc.Value, @"\D+");
                        double sum = 0;
                        double x = 0;
                        double number = 0;
                        foreach (string value in digits)
                        {

                            if (double.TryParse(value, out number))

                            {

                                if (sum == 0)
                                {

                                    sum += number;

                                }

                            }

                        }
                        x = sum - number;
                        string some = x.ToString();
                        third = Regex.Replace(line, @"\w*\d+\-+\d\w*", some);
                       
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void _last(string line, string third)
        {

            try
            {
                if (third != null)
                {
                    MatchCollection q = Regex.Matches(third, @"\d+\*+\d");
                   /* if (third != last)
                    
                        third = null;*/
                    
                    foreach (Match match in q)
                    {

                        string[] digits = Regex.Split(match.Value, @"\D+");
                        double sum = 0;
                        double x = 0;
                        double number = 0;
                        foreach (string value in digits)
                        {

                            if (double.TryParse(value, out number))

                            {

                                if (sum == 0)
                                {

                                    sum += number;

                                }

                            }

                        }
                        x = sum * number;
                        string some = x.ToString();
                        last = Regex.Replace(third, @"\d+\*+\d", some);
                        File.AppendAllText(@"2.txt", last);
                    }

                }


                if (third == null)
                {
                    MatchCollection q = Regex.Matches(line, @"\d+\*+\d");
                    if (third != line)
                    {
                        third = null;
                    }
                    foreach (Match match in q)
                    {

                        string[] digits = Regex.Split(match.Value, @"\D+");
                        double sum = 0;
                        double x = 0;
                        double number = 0;
                        foreach (string value in digits)
                        {

                            if (double.TryParse(value, out number))

                            {

                                if (sum == 0)
                                {

                                    sum += number;

                                }

                            }

                        }
                        x = sum * number;
                        string some = x.ToString();
                        last = Regex.Replace(line, @"\d+\*+\d", some);
                        File.AppendAllText(@"2.txt", last);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }








        static void delenie(string line)
        {



             _first(line);
            _second(line, first);
            _third(line, second);
              _last(line,  third);

          // first = null;
          //  second = null;
          //  third = null;
        }
        static void Main(string[] args)
        {
            try
            {
                StreamReader stream = new StreamReader(@"1.txt", Encoding.Default);
                string line;
                line = stream.ReadLine();


                // Пока строки в файле не закончились
                while (line != null)
                {
                    Console.WriteLine(line);

                    delenie(line);
                   
                    // 

                    line = stream.ReadLine();
                }
                // stream.Close();
                Console.WriteLine(@"_________________________");
                Console.WriteLine(@"_________________________");
                Console.WriteLine(@"_________________________");
                StreamReader kek = new StreamReader(@"2.txt", Encoding.Default);
                string gek;
                gek = kek.ReadLine();
                while (gek != null)
                {
                    Console.WriteLine(gek);



                    

                    gek = stream.ReadLine();
                }

               // kek.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
