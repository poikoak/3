using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System.Xml.Serialization;
namespace ConsoleAppAnalizer
{
    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Alex", "Petrov", 34, 4567);
            userInterface ui = new userInterface();

            ui.Write(person);
            Console.WriteLine();

            ui.Read(person);
            Console.WriteLine();

            ui.Write(person);
            Console.Read();


            try
            {
                // бинарная сериализация
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fstream = new FileStream("student.txt", FileMode.Create, FileAccess.Write, FileShare.None);
                bf.Serialize(fstream, person);
                fstream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // десериализация одиночного объекта
            FileStream fstream2 = File.OpenRead("student.txt");
            BinaryFormatter bf2 = new BinaryFormatter();
            Person man2 = (Person)bf2.Deserialize(fstream2);
            fstream2.Close();

            man2.Print();
            Console.Read();
        }
    }



}
