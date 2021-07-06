using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Compression;
using System.Timers;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {

        static System.Timers.Timer myTimer;
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
        static void Main(string[] args)
        {
            myTimer = new System.Timers.Timer();
            myTimer.Interval = 1000;
            // указать метод, который будет запускаться по таймеру
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
            myTimer.Start();

            dirInfo = new DirectoryInfo(@"g:\SHAG lerning\911").GetDirectories();
            foreach (DirectoryInfo di in dirInfo)
            {
                Console.WriteLine(@"Without changes");
                fileInfo = di.GetFiles();
            }
            Console.ReadLine();
        }

        static void myTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string outFileName = "test.txt.bak{0}";
            DirectoryInfo[] dInfo = new DirectoryInfo(@"g:\SHAG lerning\911").GetDirectories();
          /*  foreach (DirectoryInfo di in dInfo)
            {
                FileInfo[] fInfo = di.GetFiles();
            }*/
            if (dirInfo.Length != dInfo.Length)
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

                Console.WriteLine($"Source file size: {infile.Length}");
                Console.WriteLine("Packing...\n");
            }
        }
    }
}
