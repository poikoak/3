using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class BallanceOnTheCard : State
    {
        public override void Handle(Bancomat context)
        {


            Console.WriteLine("Balance on the Credit Cart: " + context.currentMoney + "$");



            // Wait for user 
            Console.Read();
            // Изменение состояния системы
            Console.Clear();

            // Изменение состояния системы
            context.State = new Menu();
            return;
        }
    }
}
