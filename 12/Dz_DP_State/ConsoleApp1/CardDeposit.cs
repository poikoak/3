using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class CardDeposit : State
    {
        public override void Handle(Bancomat context)
        {
            Console.WriteLine("Enter Amount:");
            int Amount = Convert.ToInt32(Console.ReadLine());
            context.currentMoney += (UInt32)Amount;


            Console.WriteLine("New Balance on the Credit Cart: " + context.currentMoney + "$");

            // Wait for user 
            Console.Read();
            // Изменение состояния системы
            Console.Clear();
            context.State = new Menu();
            return;
        }
    }
}
    

