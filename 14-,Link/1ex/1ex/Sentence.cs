using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
/*Разработать класс Sentence, содержащий следующие члены класса:
- protected List<string> Words(список слов предложения)
-конструктор с строковым параметром - начальное предложение, которое нужно разбить 
на слова и слова поместить в список слов.
- Add(string word) -добавление слова в конец предложения
- Insert(int pos, string word) -вставка слова в предложение
- RemoveAt(int pos) -удаление слова по позиции
- RemoveAll(string word) -полное удаление слова из предложения (все вхождения)
-Set(string) - занесение нового предложения с разбором по словам (старое предложение удаляется)
-this[] индексатор по словам предложения
- энумератор по словам предложения
- Length - свойство только для чтения - количество слов в предложении
- Print() -печать предложения*/

namespace _1ex
{
    class Sentence : IEnumerator
    {
        // Поле класса - список string
        protected List<string> Word = new List<string>();
        // Количество слов
        uint count_wordsReadOnly = 0;
        int count_IEnumerator = 0;




        public Sentence(string path)
        {
            string source = path;


            try
            {
                // Копируем весь текст
                // string source = File.ReadAllText(path);

                /*
                                source = Regex.Replace(source, "[.!?] \s * \w*", " ");
                              //  source = Regex.Replace(source, "[@,\\.\";'\\\\]", string.Empty);
                                string[] temp = Regex.Split(source, @"\s");*/
                string temp1 = source.Split('.', '!', '?')[0];
                string[] temp = Regex.Split(temp1, @"\s");
                //Добавляем слова и считаем поля count_words 
                foreach (var word in temp)
                {
                    Word.Add(word);

                }

                count_wordsReadOnly = (uint)Word.Count;
                count_IEnumerator = (int)Word.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public  void Print()
        {
            foreach (var word in Word)
            {
                Console.WriteLine(word /*+ " "*/);
            }
           // Console.WriteLine();
            /* for (int i = 0; i < Word.Count; i++)
             {
                 Console.WriteLine(Word[i]);
             }*/


        }
        //- свойство Length  (readonly)- свойство только для чтения - количество слов в предложении
        public uint Length { get => (uint)count_wordsReadOnly; }

        // Индексатор[int wordNum] - изменяет слово по позиции
        public string this[int i]
        {
            get => Word[i];
            set
            {
                Word[i] = value;
            }
        }

        // Add(string word) -добавляет слово в конец текста
        public void Add(string word)
        {
            Word.Add(word);
            count_wordsReadOnly++;
            count_IEnumerator++;
        }

        // RemoveAt(int pos) -удаление слова по позиции
        public void RemoveAt(int i)
        {
            Word.RemoveAt(i);
            count_wordsReadOnly--;
            count_IEnumerator++;
        }
        // - RemoveAll(string word) - полное удаление слова из предложения(все вхождения)
        public void RemoveAll(string word)
        {

            Word.RemoveAll(item => item.Contains(word));
            count_wordsReadOnly--;
            count_IEnumerator++;
        }
        //- Insert(int pos, string word) - вставка слова в предложение
        public void Insert(int pos, string word)
        {

            Word.Insert(pos, word);
            count_wordsReadOnly++;
            count_IEnumerator++;
        }
        //- Set(string) - занесение нового предложения с разбором по словам(старое предложение удаляется)
        public void Set(string path)
        {

            Word.Clear();
            count_wordsReadOnly = 0;
            count_IEnumerator = 0;
            try
            {
                // Копируем весь текст
                string source = path;
                //- при загрузке текста нужно чистить все символы, кроме буквенно-числовых и символов пунктуации
                source = Regex.Replace(source, @"\s", " ");
                string[] temp = Regex.Split(source, @"\s");

                //Добавляем слова и считаем поля count_words 
                foreach (var word in temp)
                {
                    Word.Add(word);

                }

                count_wordsReadOnly = (uint)Word.Count;
                count_IEnumerator = (int)Word.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }




        // вернуть текущее значение коллекции, которая просматривается в foreach
        public object Current
        {
            get
            {

                Console.WriteLine("Current");
                return Word[count_IEnumerator];
            }
        }

        public IEnumerator GetEnumerator()
        {
            // вызов стандартного энумератора стандартной коллекции
            //return people.GetEnumerator();

            return this;
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
                count_IEnumerator = Word.Count;
                return false;
            }
        }

        public void Reset()
        {
            Console.WriteLine("Reset");
            count_IEnumerator = Word.Count;
        }

     
    }
}
