using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace ConsoleApp1
{



    class Program
    {

        //Функция возвращает количество вхождений элемента в заданном массиве чисел.
        public static int NumberOfOccurrences(int[] arr, int x)
        {
            int result = arr.Count(z => z.ToString().Contains(x.ToString()));
            return result;
        }

        //Функция принимает массив, который содержит повторяющиеся числа.Только одно число в
        //массиве не повторяется. Функция возвращает это число
        public static IEnumerable<int> GetUnique(int[] arr)
        {
            var z = arr.GroupBy(i => i).Where(i => i.Count() == 1).Select(i => i.Key);
            return z;
        }


        // Строка состоит из слов, которые разделены пробелами и могут повторяться.Функция принимает строку
        //удаляет в ней все повторяющиеся слова, оставляя их в одном экземпляре в том месте, где они первый раз встретились.

        public static string RemoveDuplicateWords(string str)
        {
            string elem = "";

            var duplicated = str.Split(' ').Distinct();
            foreach (var item in duplicated)
            {
                elem += item + " ";

            }
            return elem;
        }

        //Функция принимает строку, которая содержит буквы и цифры и возвращает число, которое состоит
        //из максимального количества цифр, идущих подряд в строке
        public static string MAX(string str)
        {
            return str.Split(str.Where(char.IsLetter).ToArray()).Max();

        }

        //Функция принимает строку, содержащую слова, разделённые пробелами, производит реверс каждого
        //слова, объединяет их в результирующую строку и возвращает эту строку
        public static string Reverse(string str)
        {
            string elem = "";
            var reverse = str.Reverse().ToArray();
            foreach (var item in reverse)
            {
                elem += item;
            }
            return elem;
        }

        // Функция принимает строку и возвращает строку, состоящую из первых букв каждого слова исходной строки
        public static string MakeString(string str)
        {
            var result = str.Split().Select(s => s[0]).ToArray();
            string elem = "";
            foreach (var item in result)
            {
                elem += item;
            }
            return elem;
        }
        //Функция принимает строку и возвращает отсортированный массив индексов заглавных букв
        public static int[] Capitals(string str)
        {
            return str.Select((value, index)
                => new { value, index }).Where(pair
                => char.IsUpper(pair.value)).Select(pair
                => pair.index).ToArray();

        }
        static void Main(string[] args)
        {

            int[] arr = new int[] { 1, 0, 2, 2, 3 };
            int elem = 0;
            Console.WriteLine($"number of elem {elem} = {NumberOfOccurrences(arr, elem)}");
            Console.Read();
            Console.Clear();


            int[] arr2 = new int[] { 0, 2, 1, 2, 0 };
            IEnumerable<int> q = GetUnique(arr2);
            Console.WriteLine("Unique:");
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.Read();
            Console.Clear();


            string HelloBigW = "Hello big world big Hello";
            string str = RemoveDuplicateWords(HelloBigW);
            Console.WriteLine(str);
            Console.Read();
            Console.Clear();


            string solve = "12hello987big98world";
            Console.WriteLine(MAX(solve));
            Console.Read();
            Console.Clear();



            string reverse = "Hello Big World";
            Console.WriteLine(Reverse(reverse));
            Console.Read();
            Console.Clear();




            string BLM = "Black Lives Matter";
            Console.WriteLine(MakeString(BLM));
            Console.Read();
            Console.Clear();




            string HelloWorld = "Hello  World";
            int[] massiv = Capitals(HelloWorld);
            foreach (var item in massiv)
            {
                Console.WriteLine(item);
            }
        }
    }
}

