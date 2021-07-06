using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Xml;

namespace ConsoleAppXMLDOM
{
    class Program
    {

        string[] NFiles = null;

        public void showAllFiles(string path, string mask, XmlDocument XmlDoc, XmlElement elem1)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);

            if (dinfo.Exists)
            {
                // Получить массив файлов в текущей папке
                try
                {
                    string[] files = Directory.GetFiles(path, mask);
                    foreach (string current in files)
                    {
                        //имя фаила 
                        XmlElement elem2 = XmlDoc.CreateElement("File");
                        XmlAttribute attr1 = XmlDoc.CreateAttribute("Name");
                        attr1.InnerText = current;
                        elem2.Attributes.Append(attr1);


                        //размер фаила 
                        long size = current.Length;
                        String strLong = size.ToString();
                        XmlAttribute attr2 = XmlDoc.CreateAttribute("Size");
                        attr2.InnerText = strLong;
                        elem2.Attributes.Append(attr2);

                       /* XmlWhitespace ws = XmlDoc.CreateWhitespace("\r\n");
                        elem2.AppendChild(ws);
                        XmlDoc.AppendChild(elem2);*/

                        elem1.AppendChild(elem2);



                        Console.WriteLine(current);
                    }





                    // Получить массив подпапок в текущей папке
                    DirectoryInfo[] dirs = dinfo.GetDirectories();
                    foreach (DirectoryInfo current in dirs)
                    {

                        // добавление элемента с атрибутом

                        /*   XmlElement elem2 = XmlDoc.CreateElement("folder");
                           XmlAttribute attr1 = XmlDoc.CreateAttribute("Name");
                           attr1.InnerText = (current.Name);
                           elem2.Attributes.Append(attr1);*/
                        /*        XmlWhitespace ws = XmlDoc.CreateWhitespace("\r\n");
                                elem2.AppendChild(ws);
                                XmlDoc.AppendChild(elem2);*/

                        Console.WriteLine("<DIR>    " + path + "\\" + current.Name);
                        showAllFiles(path + @"\" + current.Name, mask, XmlDoc, elem1);
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
            string mask = Console.ReadLine();
            Program p = new Program();
            // создание нового XML-документа
            XmlDocument doc1 = new XmlDocument();
            // создание и добавление заголовка документа
            XmlDeclaration decl = doc1.CreateXmlDeclaration("1.0", null, null);
            // добавление заголовка XML в документ
            doc1.AppendChild(decl);
            string path = (@"g:\SHAG lerning");

            //создаем хмл
            XmlElement elem1 = doc1.CreateElement("folder");
            XmlAttribute attr = doc1.CreateAttribute("Name");
            attr.InnerText = (path);
            elem1.Attributes.Append(attr);



            //передаем в функц(путь, маску поиска, Хмл фаил, елемент первой папки)
            p.showAllFiles(path, mask, doc1, elem1);




            //делаем вконце отступ
            XmlWhitespace ws = doc1.CreateWhitespace("\r\n");
            elem1.AppendChild(ws);
            doc1.AppendChild(elem1);

            //сохраняем в фаил
            XmlWriterSettings settings = new XmlWriterSettings();
            // settings.IndentChars = "\r\n";
            settings.Indent = true;

            // сохрание документа Xml при помощи XmlWriter
            XmlWriter writer = XmlWriter.Create("test.xml", settings);

            doc1.WriteTo(writer);
            writer.Flush();
            writer.Close();

        }
    }
}
