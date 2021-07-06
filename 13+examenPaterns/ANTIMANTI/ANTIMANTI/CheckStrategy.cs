using System;
using System.Collections.Generic;
using System.Text;


namespace ANTIMANTI
{
   
    abstract class CheckStrategy
    {

        public abstract void Check(string disk);

    }
   

    class SystemData
    {
      
        CheckStrategy strategy;
       
        public CheckStrategy Strategy
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
        public SystemData(CheckStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Check(string disk)
        {
            // Вызов метода Sort, объекта сортировки, ссылка на который хранится в классе
            strategy.Check(disk);
        }

        //функция для адптера
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }




  
    //стратегия 1
    class QuickFind : CheckStrategy
    {
        public override void Check(string disk)
        {
            Console.WriteLine("QuickFind!!!");
            // SystemData
            /*if (disk == "PDF")
            {*/
                PDF adaptee1 = new PDF();
                ITarget target1 = new Adapter1(adaptee1);
               
            /*}*/
          
            DLL adaptee2 = new DLL();
            EXE adaptee3 = new EXE();          
            ITarget target2 = new Adapter2(adaptee2);
            ITarget target3 = new Adapter3(adaptee3);
            Console.WriteLine(target1.GetRequest());
            Console.WriteLine(target2.GetRequest());
            Console.WriteLine(target3.GetRequest());
            Console.WriteLine("all infected files found");
        }
    }


    //стратегия 2
    class CheckDisk : CheckStrategy
    {
        public override void Check(string disk)
        {
            Console.WriteLine("CheckDisk");
            PDF adaptee1 = new PDF();
            DLL adaptee2 = new DLL();
            EXE adaptee3 = new EXE();
            ITarget target1 = new Adapter1(adaptee1);
            ITarget target2 = new Adapter2(adaptee2);
            ITarget target3 = new Adapter3(adaptee3);
            Console.WriteLine(target1.GetRequest());
            Console.WriteLine(target2.GetRequest());
            Console.WriteLine(target3.GetRequest());
            Console.WriteLine("all infected files found");



        }
    }


    //стратегия 3
    class CheckAllSistem : CheckStrategy
    {
        public override void Check(string disk)
        {
            Console.WriteLine("CheckAllSistem");

            PDF adaptee1 = new PDF();
            DLL adaptee2 = new DLL();
            EXE adaptee3 = new EXE();
            ITarget target1 = new Adapter1(adaptee1);
            ITarget target2 = new Adapter2(adaptee2);
            ITarget target3 = new Adapter3(adaptee3);
            Console.WriteLine(target1.GetRequest());
            Console.WriteLine(target2.GetRequest());
            Console.WriteLine(target3.GetRequest());
            Console.WriteLine("all infected files found");


        }
    }
}




