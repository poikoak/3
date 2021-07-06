using Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Strategy
{
    class QuickSort : SortStrategy
    {
        static int partition(int[] array, int start, int end)
        {
            int pivot = array[(start + end) / 2];
            int i = start;
            int j = end;

            while (i <= j)
            {
                while (array[i] < pivot)
                    i++;
                while (array[j] > pivot)
                    j--;
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    i++;
                    j--;
                }
            }

            return i;
        }

     

        static void qSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                int temp = partition(array, start, end);

                qSort(array, start, temp - 1);
                qSort(array, temp, end);
            }
        }

        public override void Sort(ref int[] array)
        {
            Console.WriteLine("qSort");
            qSort(array, 0, array.Length - 1);
        }
    }


}
