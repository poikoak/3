using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1ex
{
    class FileText : Text
    {

        public FileText(string _text) : base(_text) { }

        //Load - загрузка текста из файла
        public void Load(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path, Encoding.Default);
                string line;
                line = reader.ReadLine();

                //записываем все в одну строку, что бы потом передать её базовому классу
                string text = null;
                text = String.Concat(text, line);

                while (line != null)
                {
                    line = reader.ReadLine();
                    text = String.Concat(text, line);
                }
                reader.Close();

                //занесение нового текста в базовый класс
                base.Set(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Save - сохранение текста в файл
        public void Save(string path)
        {
            try
            {
                StreamWriter writer = new StreamWriter(path, false, Encoding.Default);
                foreach (Sentence sent in text)
                {
                    foreach (string w in sent)
                    {
                        if (w.Contains('.') == true)
                            writer.Write($"{w}\n");
                        else
                            writer.Write($"{w} ");
                    }
                }               
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Print - вызов метода Print базового класса
        public void Print()
        {
            base.Print();
        }

    }
}
