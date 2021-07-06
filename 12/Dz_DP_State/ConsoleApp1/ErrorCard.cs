using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ErrorCard : State
    {
        public override void Handle(Bancomat context)
        {
            Console.WriteLine("enter the card!!!");

            context.card = false;
            // Wait for user 
            Console.Read();
            // Изменение состояния системы
            Console.Clear();
            // Изменение состояния системы
            context.State = new WaitForCreditCard();
        }
    }
}
