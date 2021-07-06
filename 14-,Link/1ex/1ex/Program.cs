using System;

namespace _1ex
{
    class Program
    {
        static void Main(string[] args)
        {




            /*Sentence text = new Sentence("Meet my family keke mekeke wasd dad. dad dad dad dad dad There are five of us – my parents, my elder brother, my baby sister and me.");           
            Console.WriteLine($"WordsCount: {text.Length}");
            text.Print(); */
            /* Console.Read();
             Console.Clear();
             text[1] = "KERCH";
             text.Print();
             Console.Read();
             Console.Clear();

             Console.WriteLine($"Word index: {text[0]}");

             text.Add("Thanks");
             text.Print();
             Console.Read();
             Console.Clear();

             text.RemoveAt(3);
             text.Print();
             Console.Read();
             Console.Clear();

             text.RemoveAll("dad");
             text.Print();
             Console.Read();
             Console.Clear();

             text.Insert(1,"MAMBACHAMBA");
             text.Print();
             Console.Read();
             Console.Clear();

             text.Set("MAMBACHAMBA, kkkkk kkkkk kkkk");
             text.Print();
             Console.Read();
             Console.Clear();*/


            FileText n = new FileText("");
            n.Load("1.txt");
            Text t = n;
            t.Print();
            Console.Read();
            Console.Clear(); 

            FileText w = new FileText("");
            w.Load("2.txt");
            w.Print();
            Console.Read();
            Console.Clear();


            w.Add(new Sentence("KEK"));
            w.Print();
            Console.Read();
            Console.Clear();


           /* w.RemoveAt(2);
            w.Print();
            Console.Read();
            Console.Clear();*/

            w.Set("chamba. MAMAba. cheburek?");
            Console.WriteLine($"number of offers: {t.Length}");
            w.Print();
            Console.Read();
            Console.Clear();


            if (t == w)
            {
                Console.WriteLine("Same text");
            }
            Console.Read();
            Console.Clear();
            if (t != w)
            {
                Console.WriteLine("Not same text");
            }

        }
    }
}
