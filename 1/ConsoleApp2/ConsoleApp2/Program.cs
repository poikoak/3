using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        void print(int[,]a,int row,int col)
        {

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write($"{a[i, j]} ");
                }
                Console.WriteLine();
            }


        }

        void random(int[,] a, int row, int col)
        {

            Random r = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    a[i, j] = r.Next(1, 10);
                }

            }


        }


        void sort(int[,] a, int row, int col)
        {
            Console.WriteLine("Sort");
            int temp, current;
            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < col; k++)
                {
                    temp = a[i, k];
                    for (current = k - 1; current >= 0 && a[i, current] < temp; current--)
                        a[i, current + 1] = a[i, current];
                    a[i, current + 1] = temp;
                }
            }
            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < col; k++)
                {
                    temp = a[i, k];
                    for (current = i - 1; current >= 0 && a[current, k] < temp; current--)
                        a[current + 1, k] = a[current, k];
                    a[current + 1, k] = temp;
                }
            }


        }
        static void Main(string[] args)
        {

            /*int[,] matrix = new int[3, 5];
            Random rand = new Random();


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i][k] = rand.Next(0, 10);
                    Console.Write($"{matrix[i, k]} ");
                }
                Console.WriteLine();
            }
            //int[] array = new int[] { 3, 1, 4, 5, 2 };
            //int[,] matrix = new int[3, 5];
            Random rand = new Random();

            int[,] array = new int[5, 5];

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    array[i, j] = random.Next(100);
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Array.Sort<int>(array,
                            new Comparison<int>(
                                    (i1, i2) => i1.CompareTo(i2)
                            ));*/

            Program s = new Program();
            int rows;
            Console.WriteLine("сколько строк?");
            rows = Convert.ToInt16(Console.ReadLine());
            int col;
            Console.WriteLine("сколько столбцов?");
            col = Convert.ToInt16(Console.ReadLine());
            int[,] a = new int[rows, col];

            s.random(a, rows, col);            
            s.print(a, rows, col);
            s.sort(a, rows, col);
            s.print(a, rows, col);          
           
           
           
        }

    }


}




