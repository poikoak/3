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
        static List<string> lst = new List<string>();
        static int count = 1;
        static long totalSize = 0;
       /* public long SizeB(string path)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);
            if (System.IO.Directory.Exists(path + @"\" + @".vs"))
            {
                DirectoryInfo DelDir = new DirectoryInfo(path + @"\" + @".vs");
                totalSize += DelDir.EnumerateFiles().Sum(file => file.Length);
            }
            DirectoryInfo[] dirs = dinfo.GetDirectories();
            foreach (DirectoryInfo current in dirs)
            {

                Console.WriteLine("<DIR>    " + path + "\\" + current.Name);
                SizeB(path + @"\" + current.Name);

            }
            return totalSize;
        }*/
        public void showAllFiles(string path)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);

            if (dinfo.Exists)
            {
              
                // Получить массив файлов в текущей папке
                try
                {
                    string vs = @".vs";
                    string Debug = @"Debug";
                    
                    DirectoryInfo[] dirs1 = dinfo.GetDirectories();
                   
                    foreach (DirectoryInfo current in dirs1)
                    {
                      
                        if (System.IO.Directory.Exists(path + @"\" + vs))
                        {
                           
                            try
                            {
                                totalSize += current.EnumerateFiles().Sum(file => file.Length);
                                Console.WriteLine("<DIR>    " + path + "\\" + current.Name);
                                System.IO.Directory.Delete(path + @"\" + vs, true);
                                totalSize += current.EnumerateFiles().Sum(file => file.Length);
                                count++;
                            
                                    lst.Add("<DIR>    " + path + "\\" + current.Name);
                                    File.WriteAllLines("AllFiles.txt", lst);


                                
                            }

                            catch (System.IO.IOException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        if (System.IO.Directory.Exists(path + @"\" + Debug))
                        {
                            try
                            {
                                totalSize += current.EnumerateFiles().Sum(file => file.Length);
                                Console.WriteLine("<DIR>    " + path + "\\" + current.Name);
                                System.IO.Directory.Delete(path + @"\" + Debug, true);

                                lst.Add("<DIR>    " + path + "\\" + current.Name);
                                File.WriteAllLines("AllFiles.txt", lst);

                                count++;
                            }

                            catch (System.IO.IOException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                                   

                    // Получить массив подпапок в текущей папке
                    DirectoryInfo[] dirs = dinfo.GetDirectories();
                    foreach (DirectoryInfo current in dirs)
                    {

                      //  Console.WriteLine("<DIR>    " + path + "\\" + current.Name);
                        showAllFiles(path + @"\" + current.Name);
                       
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
            Console.WriteLine(@"Program delete all *.vs* and *Debug* <DIR>");
           // string mask = Console.ReadLine();
            Program p = new Program();
            //p.SizeB(@"g:\SHAG lerning\911");
            p.showAllFiles(@"g:\SHAG lerning");
        
            Console.WriteLine("Всего файлов {0}.", count);
            Console.WriteLine("Всего файлов {0}.", totalSize);
          
        }
    }

}
