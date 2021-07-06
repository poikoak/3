using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Compression;
using System.IO;


// объявление типа данных делегат
delegate int Subscriber(string str);

class Server
{
    static System.Timers.Timer myTimer;

    static FileInfo[] fileInfo = null;
 
    // создание переменной-списка адресов функций (event)
    protected event Subscriber subsribers;

    // метод, подписывающий клиентские классы на сообщения
    public void Add(Subscriber ev)
    {
        // оператор += добавляет ссылку на метод в event
        subsribers += ev;
    }

    // метод, отписывающий клиентские классы на сообщения
    public void Remove(Subscriber ev)
    {
        // оператор -= удаляет ссылку на метод из event
        subsribers -= ev;
    }

    // метод, стартующий событие и вызывающий обработчики события в классах-подписчиках
    public void StartEvent(string str)
    {
        // если есть подписчики, то сообщить им о событии (вызвать их обработчики)
        /*if(subsribers != null)
            subsribers(str);*/
        myTimer = new System.Timers.Timer(2000);
        myTimer.Interval = 1000;
        //метод который мы вызываем в тике
        myTimer.Elapsed += Start_;
        myTimer.Start();
        // subsribers?.Invoke(str);
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"i = {i}");
            Thread.Sleep(150);
        }

    }
    public void Start_(object str1, ElapsedEventArgs e)
    {
        //обджект делаем стрингом чтобы передать сигнал клиентам, так-как у клиентов функций принемают стринг
        string str = str1.ToString();      
        subsribers?.Invoke(str);
    }



}

// первый класс-подписчик выводит на экран время
class Client1                                       
{
    // обработчик события
    public int EventWrite(string str)
    {
        Console.WriteLine("Client 1: {0}", DateTime.Now);
        return 0;
    }
}

// второй класс подписчик сохраняет в фаил
class Client2
{
    // обработчик события    
    public int EventSave(string str)
    {
        Console.WriteLine("Client 2: SaveTime");
        File.AppendAllText(@"time.txt", DateTime.Now.ToString() + "\n");
        
        return 0;
    }
}
// третий класс подписчик вырубает программу когда тикнет 10 сек

class Client3
{
    int count;
    // обработчик события
    public int EventClose(string str)
    {

        count++;
        if (count == 10)
        {
            Console.WriteLine("Client 3: stop server");
           
            System.Environment.Exit(0);
           

        }
        return 0;
    }



   
}
class Program
{
    static void Main(string[] args)
    {
        // создание подписчиков и сервера
        Client1 c1 = new Client1();
        Client2 c2 = new Client2();
        Client3 c3 = new Client3();
        Server server = new Server();

        // подписка на события
        server.Add(c1.EventWrite);
        server.Add(c2.EventSave);
        server.Add(c3.EventClose);
      

        // старт события на сервере
        server.StartEvent("Alarm !!! Fire !!!");

      
        
    }
}
