using System;
using System.Collections.Generic;
using System.Text;

namespace ANTIMANTI
{

    interface IObserver
    {
        void Update(Object ob);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    class Stock : IObservable
    {
        StockInfo sInfo;

        List<IObserver> observers;
        public Stock()
        {
            observers = new List<IObserver>();
            sInfo = new StockInfo();
        }
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(sInfo);
            }
        }

        public void Notify()//Я ХОЧУ ЗАСУНУТЬ СЮДА АДАПТЕР
        {

            NotifyObservers();
        }
    }

    class StockInfo
    {
        public bool ActivatedPremium = true;

    }

    class Premium : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Premium(IObservable obs)
        {

            stock = obs;
            stock.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if (sInfo.ActivatedPremium == true)

                OpenFunctional();
        }
        public void StopPremium()
        {
            Console.WriteLine("You have a regular version");

            stock.RemoveObserver(this);
            stock = null;
        }

        private void OpenFunctional()
        {
            //открывает весь новый функционал 

        }
    }

    /*class OpenFunctional : IObserver
    {

        IObservable stock;
        public OpenFunctional(IObservable obs)
        {

            stock = obs;
            stock.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if (sInfo.ActivatedPremium == true)
                NewFunc();

        }

        private void NewFunc()
        {//открывает весь новый функционал 

        }
*/

}

