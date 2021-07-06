using System;
using System.Text.RegularExpressions;
namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            string prog = "мир";
            Console.WriteLine("Программа:");
            Console.WriteLine(prog);
            int countfor=0;
            int countif=0;
            int countint = 0;
            foreach (Match m in Regex.Matches(prog, @"\w*ир$"))
            {
                countif++;
                // Console.WriteLine(m.Value);
               
            }
            foreach (Match m in Regex.Matches(prog, @"\w?for\s?.+?;"))
            {
                countfor++;
                // Console.WriteLine(m.Value);
             
            }
            foreach (Match m in Regex.Matches(prog, @"\wые\s?.+?;"))
            {
                countint++;
                //  Console.WriteLine(m.Value);
               
            }

            Console.WriteLine(@"операторов if {0}", countif);
            Console.WriteLine(@"операторов for {0}", countfor);
            Console.WriteLine(@"операторов {0}", countint);
        }
    }
}
