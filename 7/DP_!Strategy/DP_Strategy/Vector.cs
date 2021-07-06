using DP_Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Vector
    {


        // Ссылка на объект, занимающийся сортировкой
        SortStrategy strategy;
        int[] array = { 3, 4, 5, 6, 1, 2, 3, 4, 45, 23, 32, 111 };
       

        public SortStrategy Strategy
        {
            get
            {
                return strategy;
            }
            set
            {
                strategy = value;
            }
        }




        // Constructor 
        public Vector(SortStrategy strategy)
        {

            this.strategy = strategy;

        }

        

        public void Sort()
        {
            // Вызов метода Sort, объекта сортировки, ссылка на который хранится в классе
            strategy.Sort(ref array);
        }

        public void PrintArray()
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine();
        }

    }
}
