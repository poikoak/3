using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Bancomat 
    {
        // Текущее состояние системы
        private State currentState;

        // Денег на счету
        public UInt32 currentMoney= 1000;

        // Депозит
        public UInt32 currentMoneyDeposit;

        // снятие денег
        public UInt32 Amount;

        // банковская карта
        public bool card;

        // проверка пароля карты
        public bool pass;


        // Constructor, принимает начальное состояние системы
        public Bancomat(State state)
        {
            this.State = state;
        }

        // Property - текущее состояние системы
        public State State
        {
            get { return currentState; }
            set
            {
                currentState = value;
                Console.WriteLine("State: " + currentState.GetType().Name);
            }
        }

        public void Start()
        {
            while (true)
            {
                Request();
                
            }
        }

        // Запрос на изменение состояния
        public void Request()
        {
            currentState.Handle(this);
        }



    }
}
