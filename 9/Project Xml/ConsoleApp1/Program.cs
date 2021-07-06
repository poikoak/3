using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public void OpenXml()
        {
            // объект для чтения XML
            XmlReader reader;

            // открытие существующего файла
            reader = XmlReader.Create("test.xml");

            // читать файл по одному тегу
            while (reader.Read())
            {
                // проверка разных типов узлов XML

                if (reader.NodeType == XmlNodeType.Comment)
                {
                    Console.WriteLine("<!--" + reader.Value + " -->\r\n");
                }

                if (reader.NodeType == XmlNodeType.Element || reader.NodeType == XmlNodeType.XmlDeclaration)
                {
                    // если есть атрибуты в элементе
                    if (reader.HasAttributes)
                    {
                        Console.Write("\n<" + reader.Name + " ");

                        // переместить указатель на чтение атрибутов
                        reader.MoveToFirstAttribute();

                        // вывод данных текущего атрибута
                        Console.Write(reader.Name + " = " + reader.Value + " ");

                        // вывод информации обо всех атрибутах элемента
                        while (reader.MoveToNextAttribute())
                        {
                            Console.Write(reader.Name + " = " + /*reader.Value*/reader[reader.Name] + " ");
                        }

                        // переместить указатель на элменты
                        reader.MoveToElement();

                        // проверка на наличие дочерних элементов
                        if (reader.IsEmptyElement)
                            Console.Write("/>");
                        else
                            Console.Write(">");
                    }
                    else
                    {
                        // проверка на наличие дочерних элементов
                        if (reader.IsEmptyElement)
                        {
                            Console.Write("\n<" + reader.Name + "/>");
                        }
                        else
                            Console.Write("\n<" + reader.Name + ">");
                    }
                }

                if (reader.NodeType == XmlNodeType.Text)
                    Console.Write(reader.Value);

                if (reader.NodeType == XmlNodeType.EndElement)
                    Console.WriteLine("\n</" + reader.Name + ">");
            }



        }



        public void showAllFiles(string path, XmlWriter writer)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);

            if (dinfo.Exists)
            {
                // Получить массив файлов в текущей папке
                try
                {
                    FileInfo[] files = dinfo.GetFiles();
                    foreach (FileInfo current in files)
                    {
                        long size = current.Length;
                        String strLong = size.ToString();
                        string Name = current.Name.ToString();
                        writer.WriteStartElement("File");
                        writer.WriteAttributeString("name", Name);
                        writer.WriteAttributeString("size", strLong);
                        writer.WriteEndElement();
                        Console.WriteLine("file name = " + current.FullName + ", size = " + strLong);

                    }

                    // Получить массив подпапок в текущей папке
                    DirectoryInfo[] dirs = dinfo.GetDirectories();
                    foreach (DirectoryInfo current in dirs)
                    {

                        // вывести заголовок XML
                        writer.WriteStartDocument();
                        // записать начальный тег элемента
                        writer.WriteStartElement("Folder");
                        string Name = current.Name.ToString();               
                        writer.WriteAttributeString("name", null, path);                     
                        writer.WriteAttributeString("_", Name);



                        Console.WriteLine("<DIR>    " + path + "\\" + current.Name);
                        showAllFiles(path + @"\" + current.Name, writer);
                        writer.WriteEndElement();
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
            Program p = new Program();
         /*   // класс для записи XML
            XmlWriter writer;

            // настройки записи
            XmlWriterSettings settings = new XmlWriterSettings();

            // перенос на новые строки
            settings.Indent = true;

            // символы перехода на следующую строку
            settings.NewLineChars = "\r\n";

            // кодировка
            settings.Encoding = Encoding.ASCII;

            // переход на новую строку для атрибутов
            settings.NewLineOnAttributes = false;

            // создание нового файла
            writer = XmlWriter.Create("test.xml", settings);

            p.showAllFiles(@"g:\123", writer);


            // закрытие записи всего документа
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();*/


             p.OpenXml();




        }
    }
}
