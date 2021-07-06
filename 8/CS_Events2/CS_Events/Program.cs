using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Compression;
using System.IO;

namespace ConsoleApp2
{
    // объявление типа данных делегат
    delegate int Subscriber(string str);

     class Server
    {
        static System.Timers.Timer myTimer;
        static DirectoryInfo[] dirInfo = null;
        static FileInfo[] fileInfo = null;



        static FileStream destFile, infile;
        static GZipStream compressedzipStream;
        static string sourceName, compressedName, decompressedName;
        static int outFileNumber = 1;

        // создание переменной-списка адресов функций (event)
        protected event Subscriber subsribers;

        private static void EndWrite(IAsyncResult result)
        {
            Console.WriteLine("Compression successful!\n");
            Console.WriteLine($"Result file size: {destFile.Length}");

            // result.AsyncState - опциональный параметр, переданный из вызова метода BeginWrite
            Console.WriteLine($"AsyncState parameter received: {result.AsyncState.ToString()}");

            // закрытие потоков по окончании сжатия
            infile.Close();
            compressedzipStream.Close();
            destFile.Close();
        }
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
            // если есть подписчики, то сообщить им о событии (вызвать их обработчики)
            /*if(subsribers != null)
                subsribers(str);*/
            myTimer = new System.Timers.Timer(2000);
            myTimer.Interval = 1000;
            //метод который мы вызываем в тике
            myTimer.Elapsed += Start_;
            myTimer.Start();
            dirInfo = new DirectoryInfo(@"g:\SHAG lerning\911").GetDirectories();
            foreach (DirectoryInfo di in dirInfo)
            {
                Console.WriteLine(@"Without changes");
                fileInfo = di.GetFiles();
            }
            Console.ReadLine();

        }
        public void Start_(object str1, ElapsedEventArgs e)
        {
            //обджект делаем стрингом чтобы передать сигнал клиентам, так-как у клиентов функций принемают стринг
            string str = str1.ToString();
            DirectoryInfo[] dInfo = new DirectoryInfo(@"g:\SHAG lerning\911").GetDirectories();
            /*  foreach (DirectoryInfo di in dInfo)
              {
                  FileInfo[] fInfo = di.GetFiles();
              }*/
            if (dirInfo.Length != dInfo.Length)
            {
                subsribers?.Invoke(str);
            }
        }



    }

    // первый класс-подписчик выводит на экран время
    class Client1
    {

       
        static DirectoryInfo[] dirInfo = null;
        static FileInfo[] fileInfo = null;
        static FileStream destFile, infile;
        static GZipStream compressedzipStream;
        static string sourceName, compressedName, decompressedName;
        static int outFileNumber = 1;

        private static void EndWrite(IAsyncResult result)
        {
            Console.WriteLine("Compression successful!\n");
            Console.WriteLine($"Result file size: {destFile.Length}");

            // result.AsyncState - опциональный параметр, переданный из вызова метода BeginWrite
            Console.WriteLine($"AsyncState parameter received: {result.AsyncState.ToString()}");

            // закрытие потоков по окончании сжатия
            infile.Close();
            compressedzipStream.Close();
            destFile.Close();
        }
        // обработчик события
        public int EventWrite(string str)
        {
            string outFileName = str;
            {
                Console.WriteLine("The number of folders in the directory does not match!");
                Console.WriteLine("Start arhivation of folder");
                dirInfo = new DirectoryInfo(@"g:\SHAG lerning\911").GetDirectories();
                //архивируем
                sourceName = (@"g:\SHAG lerning\911");
                compressedName = string.Format(outFileName, outFileNumber++);
                // сжатый файл (вначале пустой)
                destFile = File.Create(compressedName);
                // исходный файл
                infile = new FileStream(sourceName, FileMode.Open, FileAccess.Read, FileShare.Read);

                // буфер в памяти
                byte[] buffer = new byte[infile.Length];

                infile.Read(buffer, 0, buffer.Length);

                // создание сжимающего потока
                compressedzipStream = new GZipStream(destFile, CompressionMode.Compress, true);
                // указать метод, который будет вызван автоматически, когда сжатие закончится
                AsyncCallback callBack = new AsyncCallback(EndWrite);

                compressedzipStream.BeginWrite(buffer, 0, buffer.Length, callBack, 33);
            }
            return 0;
        }
    }
    // второй класс подписчик сохраняет в фаил
    class Client2
    {
        // обработчик события    
        public int EventSave(string str)
        {
            string infile = str;
            Console.WriteLine("Client 2: ShowArhiv");
            Console.WriteLine($"Source file size: {infile.Length}");
            Console.WriteLine("Packing...\n");
            return 0;
        }
    }
    // третий класс подписчик вырубает программу когда тикнет 10 сек

    class Client3
    {
        int count;
        // обработчик события
        public int EventClose(string str)
        {

            count++;
            if (count == 10)
            {
                Console.WriteLine("Client 3: stop server");

                System.Environment.Exit(0);


            }
            return 0;
        }




    }
    class Program
    {
        static void Main(string[] args)
        {
            // создание подписчиков и сервера
            Client1 c1 = new Client1();
            Client2 c2 = new Client2();
            Client3 c3 = new Client3();
            Server server = new Server();
          

            // подписка на события
            server.Add(c1.EventWrite);
            server.Add(c2.EventSave);
            server.Add(c3.EventClose);


            // старт события на сервере
            server.StartEvent("test.txt");



        }
    }
}