using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        void Test(int size)
        {
            Console.WriteLine("Тест");
            Random rand = new Random();
              int[] arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1, 5);
               // Console.Write($"{arr[i]} ");
                Console.WriteLine(String.Join(",", $"{ arr[i]}".OrderBy(x => x)));
            }
          
        }
        static int[] BubbleSort(int[] arr)
        {
            Console.WriteLine("BubbleSort");
           
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {              
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;                      
                    }
                }              
            }
            return arr;
        }


        static int[] ViborSort(int[] arr)
        {
            Console.WriteLine("ViborSort");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                //обмен элементов
                int temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }
        static int[] SortInsertMethod(int[] arr)
        {
            Console.WriteLine("SortInsertMethod");
            int x, i, j;
            for (i = 0; i < arr.Length; i++)
            {
                x = arr[i];
                for (j = i - 1; j >= 0 && arr[j] > x; j--)
                    arr[j + 1] = arr[j];

                arr[j + 1] = x;
            }
            return arr;
        }

        class QuickSorting
        {
            public static void sorting(int[] arr, long first, long last)
            {
               
                int p = arr[(last - first) / 2 + first];
                int temp;
                long i = first, j = last;
                while (i <= j)
                {
                    while (arr[i] < p && i <= last) ++i;
                    while (arr[j] > p && j >= first) --j;
                    if (i <= j)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        ++i; --j;
                    }
                }
                if (j > first) sorting(arr, first, j);
                if (i < last) sorting(arr, i, last);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("размер массива?");
            int size = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            int[] arr = new int[size];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1, 5);
            }                    
          
            BubbleSort(arr);
            Console.WriteLine("После сортировки:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        

            ViborSort(arr);
            Console.WriteLine("После сортировки:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
           

            SortInsertMethod(arr);
            Console.WriteLine("После сортировки:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }


            Console.WriteLine("QuickSorting");
            QuickSorting.sorting(arr, 0, arr.Length - 1);
            Console.WriteLine("После сортировки:");
            foreach (int x in arr)
            {
                System.Console.Write(x + "\n");
            }
            
        }
    }
}
