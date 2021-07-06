using System;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            client1 c1 = new client1();
            client2 c2 = new client2();
         
            Server server = new Server();


            // подписка на события
            server.Add(c1.EventWriteDictoinary);
            server.Add(c2.EventSaveLog);
       


            // старт события на сервере
            server.StartEvent("kek");
        }
    }
}
