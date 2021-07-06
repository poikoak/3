using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class AmountSelection : State
    {
        public override void Handle(Bancomat context)
        {
            Console.WriteLine("Enter Amount:");
            int Amount = Convert.ToInt32(Console.ReadLine());
            do
            {
                

                if (Amount > context.currentMoney)
                {
                    Console.WriteLine("Wrong Amount");
                    return;
                }


                context.currentMoney -= (UInt32)Amount;

            } while (context.currentMoney <= Amount);


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
