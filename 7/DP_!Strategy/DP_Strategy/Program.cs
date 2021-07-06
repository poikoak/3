using DP_Strategy;
using System;

namespace Strategy
{
    class MainApp
    {
        static void Main()
        {
           
            var sort = new QuickSort();
            var context = new Vector(sort);
            context.PrintArray();
            context.Sort();           
            context.PrintArray();



            var sort2 = new BubbleSort();
            var context2 = new Vector(sort2);
            context2.PrintArray();
            context2.Sort();
            context2.PrintArray();

            var sort3 = new InsertionSort();
            var context3 = new Vector(sort3);
            context3.PrintArray();
            context3.Sort();
            context3.PrintArray();


            var sort4 = new SelectionSort();
            var context4 = new Vector(sort4);
            context4.PrintArray();
            context4.Sort();
            context4.PrintArray();

        }
     
    }





}
