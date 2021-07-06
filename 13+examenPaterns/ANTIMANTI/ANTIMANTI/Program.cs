using System;

namespace ANTIMANTI
{
    class Program
    {
        static void TreatmentOfFails()
        {

            Console.Clear();
            Int32 i;
            {
                {
                    Console.WriteLine("What do with infected files?");
                    Console.Write("Menu:\n1) Delete \n2) Treat \n3) Ignor \n\nYour choise: ");
                    i = Int32.Parse(Console.ReadLine());
                    switch (i)
                    {
                        case 1:
                            {

                                BuilderDepartment editor = new BuilderDepartment();
                                IDocumentBuilder b1 = new Delete();
                                object FilesThatAreScannedAndInfected = "FilesThatAreScannedAndInfected";
                                editor.Treat(FilesThatAreScannedAndInfected, b1);
                                editor.Show();
                            }
                            break;
                        case 2:
                            {
                                BuilderDepartment editor = new BuilderDepartment();
                                IDocumentBuilder b1 = new Treat();
                                object FilesThatAreScannedAndInfected = "FilesThatAreScannedAndInfected";
                                editor.Treat(FilesThatAreScannedAndInfected, b1);
                                editor.Show();
                            }
                            break;
                        case 3:
                            {
                                BuilderDepartment editor = new BuilderDepartment();
                                IDocumentBuilder b1 = new Ignor();
                                object FilesThatAreScannedAndInfected = "FilesThatAreScannedAndInfected";
                                editor.Treat(FilesThatAreScannedAndInfected, b1);
                                editor.Show();
                            }
                            break;
                        default:
                            Console.WriteLine("You pressed something else...");
                            break;
                    }
                    Console.Write("\nEnter your choise...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }


        }





        static void Update()
        {
            //вызываем синглотон сначала показывает базовый текст потом вроде как обновление
            Console.WriteLine(DownloadBaseAntivir.text);
            DownloadBaseAntivir singleton = DownloadBaseAntivir.GetInstance();
            //Console.WriteLine(singleton.Date);
            ///////////////////
            ///////////////////
           
        }






        static void Premium()
        {
            Console.WriteLine("Want to activate premium?");
            Console.WriteLine("Click on y / n");
            string selection = Console.ReadLine();
            Console.Clear();
            if (selection == "y")
                Console.WriteLine("Your version of the program is now Premium, ads are disabled and new goodies have arrived");
            Stock stock = new Stock();
            Premium prem = new Premium(stock);
            stock.Notify();
            if (selection == "n")
                Console.WriteLine("You refused");
            // сделать выключение премиума по дате         
            //if (data== ending)            
            // prem.StopPremium();
            ///////////////////
            ///////////////////
            ///
            Console.WriteLine("press any button");
            Console.ReadLine();
            Console.Clear();

        }

        static void Menu()
        {

            SystemData infectedData;
            Int32 i;
            {
                {
                    Console.Write("Menu:\n1) QuickFind \n2) CheckDisk \n3) CheckAllSistem \n\nYour choise: ");
                    i = Int32.Parse(Console.ReadLine());
                    switch (i)
                    {
                        case 1:
                            {
                                infectedData = new SystemData(new QuickFind());
                                infectedData.Check("check fast all master files");
                                Console.WriteLine("press any button");
                                Console.ReadLine();
                                TreatmentOfFails();


                            }
                            break;
                        case 2:
                            {
                                Console.WriteLine("Choose what disk need to check");
                                string disk = Console.ReadLine();
                                infectedData = new SystemData(new CheckDisk());
                                infectedData.Check(disk);
                                Console.WriteLine("press any button");
                                Console.ReadLine();
                                TreatmentOfFails();
                            }
                            break;
                        case 3:
                            {

                                infectedData = new SystemData(new CheckAllSistem());
                                infectedData.Check("Checking all system");
                                Console.WriteLine("press any button");
                                Console.ReadLine();
                                TreatmentOfFails();
                            }
                            break;
                        default:
                            Console.WriteLine("You pressed something else...");
                            break;
                    }
                    Console.Write("\nEnter your choise...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }






        static void Main(string[] args)
        {
            //обновление программы при входе сингл
            Update();
            //покупка премиума обсервер
            Premium();
            //меню выбора какую проверку сделать(Стратегия и Адаптер)
            //меню выбора способа лечения зараженного фаийла(Билдер)
            Menu();
        }
    }
}

















