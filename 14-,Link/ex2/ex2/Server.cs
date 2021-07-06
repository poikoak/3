using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Compression;
using System.IO;
using System.Text.RegularExpressions;

namespace ex2
{

    // объявление типа данных делегат
    delegate int Subscriber(string str);

    class Server
    {
        static DirectoryInfo[] dirInfo = null;
        static int count1 =1 ;
        static int count2 =1;
        static int count3 =1;
        static int count4 =1;

       
        

        string path = @"g:\SHAG lerning\911";
        string mask = @"*.txt";
        static System.Timers.Timer myTimer;

        static FileInfo[] fileInfo = null;

        // создание переменной-списка адресов функций (event)
        protected event Subscriber subsribers;

        // метод, подписывающий клиентские классы на сообщения
        public void Add(Subscriber ev)
        {
            // оператор += добавляет ссылку на метод в event
            subsribers += ev;
        }

        // метод, отписывающий клиентские классы на сообщения
        public void Remove(Subscriber ev)
        {
            // оператор -= удаляет ссылку на метод из event
            subsribers -= ev;
        }

        // метод, стартующий событие и вызывающий обработчики события в классах-подписчиках
        public void StartEvent(string str)
        {
            
            myTimer = new System.Timers.Timer(2000);
            myTimer.Interval = 1000;
            //метод который мы вызываем в тике
            showAllFiles(path, mask);
            myTimer.Elapsed += Start_;
            myTimer.Start();
           /* Console.ReadKey();*/
            dirInfo = new DirectoryInfo(path).GetDirectories();           
            Console.ReadKey();

        }
        public void Start_(object str1, ElapsedEventArgs e)
        {
            Console.WriteLine("Start_");
            string str = str1.ToString();
              DirectoryInfo[] dInfo = new DirectoryInfo(path).GetDirectories();

              if (dirInfo.Length != dInfo.Length)
              {
                Console.WriteLine(@"CHANGES ");
                showAllFiles(path, mask);
                dirInfo= new DirectoryInfo(path).GetDirectories();
              }
           

        }



        public void showAllFiles(string path, string mask)
        {
            Console.WriteLine("showAllFiles");
            DirectoryInfo dinfo = new DirectoryInfo(path);

            if (dinfo.Exists)
            {
                // Получить массив файлов в текущей папке
                try
                {
                    string[] files = Directory.GetFiles(path,mask);

                    // Console.WriteLine("Всего файлов {0}.", files.Length);
                    
                    foreach (string f in files)
                    {
                        Console.WriteLine(f);
                        if (count1 == 1 )
                        {
                            foreach (Match m in Regex.Matches(f, @"\w*ая"))
                            {
                                Console.WriteLine(f);
                                count1++;
                                subsribers?.Invoke(f);

                            }
                        }

                        if (count2 == 1)
                        {
                            foreach (Match m in Regex.Matches(f, @"\w*ый"))
                            {
                                Console.WriteLine(f);
                                count2++;
                                subsribers?.Invoke(f);

                            }
                        }

                        if (count3 == 1 )
                        {
                            foreach (Match m in Regex.Matches(f, @"\w*ое"))
                            {
                                Console.WriteLine(f);
                                count3++;
                                subsribers?.Invoke(f);

                            }
                        }

                        if (count4 == 1)
                        {
                            foreach (Match m in Regex.Matches(f, @"\w*ые"))
                            {
                                Console.WriteLine(f);
                                count4++;
                                subsribers?.Invoke(f);

                            }
                        }                 

                    }

                    // Получить массив подпапок в текущей папке
                    DirectoryInfo[] dirs = dinfo.GetDirectories();
                    foreach (DirectoryInfo current in dirs)
                    {
                        // Console.WriteLine("<DIR>    " + path + "\\" + current.Name);
                        showAllFiles(path + @"\" + current.Name,mask);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Path is not exists");
            }
        }
    }
}
