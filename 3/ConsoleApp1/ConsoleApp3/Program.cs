using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
namespace ConsoleApp3
{
    class Program
    {
        static int count = 1;
        string[] NFiles = null;
        List<string> lst = new List<string>();
        public void showAllFiles(string path, string mask)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);
   
                if (dinfo.Exists)
                {
                    // Получить массив файлов в текущей папке
                    try
                    {
                    string[] files = Directory.GetFiles(path, mask);
                     
                   // Console.WriteLine("Всего файлов {0}.", files.Length);
                   
                        foreach (string f in files)
                        {
                            Console.WriteLine(f);
                           count++;
                        lst.Add(f);
                        File.WriteAllLines("AllFiles.txt", lst);                 


                        }





                    // Получить массив подпапок в текущей папке
                    DirectoryInfo[] dirs = dinfo.GetDirectories();
                    foreach (DirectoryInfo current in dirs)
                    {
                       // Console.WriteLine("<DIR>    " + path + "\\" + current.Name);
                        showAllFiles(path + @"\" + current.Name, mask);
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
        static void Main(string[] args)
        {
            Console.WriteLine(@"enter mask *.txt, text.*: ");
            string mask = (@"*.txt");
            Program p = new Program();
            p.showAllFiles(@"g:\SHAG lerning", mask);
            Console.WriteLine("Всего файлов {0}.",  count);

        }
    }

}