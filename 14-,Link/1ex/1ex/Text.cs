using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
/*Разработать класс Text, содержащий следующие члены класса:
- protected List<Sentences>(список предложений текста)

-конструктор с строковым параметром - начальный текст, содержащий предложения,
которые ограничены знаками препинания (. ! ? ...). Для парсинга использовать регулярные выражения.
- Add(string) -добавление предложения в конец текста++
- Add(Sentence) -добавление предложения в конец текста
- Insert(int pos, string) -вставка предложения в текст
- RemoveAt(pos) -удаление предложения по позиции++
- Set(string) -занесение нового текста с разбором по предложениям++
- operator + (добавляет предложение в конец текста)
- operator ==(сравнивает 2 текста)++
- operator -(удаление всех вхождений предложения в текст)
-индексатор по предложениям текста this[s] -s - номер предложения
- индексатор по словам текста this[s, w] (s - номер предложения, w - номер слова в предложении)
-энумератор по предложениям текста++
- Length - свойство только для чтения - количество предложений в тексте++
- Print() -печать всех предложений++*/

namespace _1ex
{
    abstract class Text : IEnumerator
    {
        protected List<Sentence> text = new List<Sentence>();
        // Количество слов
        uint count_sentenceReadOnly = 0;
        int count_IEnumerator = 0;

        public Text(string path)
        {
            string source = path;


            try
            {
              
                string[] sentences = Regex.Split(source, @"(?<=[\.!\?])\s+");
                foreach (var word in sentences)
                {
                    text.Add(new Sentence(word));

                }

                count_sentenceReadOnly = (uint)text.Count;
                count_IEnumerator = (int)text.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public  void Print()
        {
            for (int i = 0; i < text.Count; i++)
            {
                text[i].Print();                
            }

        }

        //- свойство Length  (readonly)- свойство только для чтения - количество слов в предложении
        public uint Length { get => (uint)count_sentenceReadOnly; }

        public IEnumerator GetEnumerator()
        {
            // вызов стандартного энумератора стандартной коллекции
            //return people.GetEnumerator();

            return this;
        }
        // вернуть текущее значение коллекции, которая просматривается в foreach
        public object Current
        {
            get
            {

                Console.WriteLine("Current");
                return text[count_IEnumerator];
            }
        }      

        public bool MoveNext()
        {

            Console.WriteLine("MoveNext");
            if (count_IEnumerator > 0)
            {
                count_IEnumerator--;
                return true;
            }
            else
            {
                // сброс счётчика
                count_IEnumerator = text.Count;
                return false;
            }
        }

        public void Reset()
        {
            Console.WriteLine("Reset");
            count_IEnumerator = text.Count;
        }


        // Add(string word) -добавляет слово в конец текста
        public void Add(Sentence word)
        {
            text.Add(word);
            count_sentenceReadOnly++;
            count_IEnumerator++;
        }
        public void RemoveAt(int i)
        {
            text.RemoveAt(i);
            count_sentenceReadOnly--;
            count_IEnumerator++;
        }


        public void Set(string path)
        {

            text.Clear();
            count_sentenceReadOnly = 0;
            count_IEnumerator = 0;
              string source = path;


                try
                {

                    string[] sentences = Regex.Split(source, @"(?<=[\.!\?])\s+");
                    foreach (var word in sentences)
                    {
                        text.Add(new Sentence(word));

                    }

                    count_sentenceReadOnly = (uint)text.Count;
                    count_IEnumerator = (int)text.Count;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            
        }
        //оператор +(добавление предложения в конец текста)
        public static Text operator + (Text text,Sentence sentence)
        {

            text.Add(sentence);
            return text;

        }

        public bool Equals (Text txt)
        {
            if (txt == null)
                return false;
            Text i = txt as Text;
            if (i as Text == null)
                return false;
            return i.Length == this.Length;
        }

        public static bool operator ==(Text first, Text second)
        {
            if ((object)first == null && (object)second == null) return true;
            if ((object)first == null && (object)second != null) return false;
            if ((object)first != null && (object)second == null) return false;
            return first.Equals(second);
        }

        public static bool operator !=(Text first, Text second)
        {
            if ((object)first == null && (object)second == null) return true;
            if ((object)first == null && (object)second != null) return false;
            if ((object)first != null && (object)second == null) return false;
            return !first.Equals(second);
        }
    }
}
