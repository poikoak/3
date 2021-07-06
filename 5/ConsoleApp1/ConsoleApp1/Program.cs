using System;
using System.Text.RegularExpressions;
namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            string prog = "int main(void)\n" +
                "{\n\t" + "if (true)" +
                "{ for (int i = 0; i < 10; i++){Console.WriteLine(i); }}" +
                 "{\n\t" + "int i = 10;" +
                "\n\tint j = i * i;" +
                "\n\tConsole.WriteLine(i + j);\n\treturn 0;\n}";
            Console.WriteLine("Программа:");
            Console.WriteLine(prog);
            int countfor=0;
            int countif=0;
            int countint = 0;
            foreach (Match m in Regex.Matches(prog, @"\w?if\s"))
            {
                countif++;
                // Console.WriteLine(m.Value);
               
            }
            foreach (Match m in Regex.Matches(prog, @"\w?for\s"))
            {
                countfor++;
                // Console.WriteLine(m.Value);
             
            }
            foreach (Match m in Regex.Matches(prog, @"\w?int\s"))
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
