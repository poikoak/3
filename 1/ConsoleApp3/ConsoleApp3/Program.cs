using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("choose a number from 1 to 5. You have 5 attempts to guess the number");

            int number = new Random().Next(1,10);
            int attempts = 5;

            do
            {
                Console.Write(" <Enter number>:");
                int input = int.Parse(Console.ReadLine());
                if (input == number)
                {
                    Console.WriteLine("WIN!");
                    goto done;
                }               
                else if (input < number)
                    Console.WriteLine("Not guessing.Your number is greater");
                else if (input > number)
                    Console.WriteLine("Not guessing. Your number is less");
            } while (attempts-- > 0);


Console.WriteLine("mission failed!");

        done:
            Console.ReadKey();





        }
    }
}
