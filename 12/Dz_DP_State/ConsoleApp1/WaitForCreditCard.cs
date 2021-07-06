using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class WaitForCreditCard : State
    {
        public override void Handle(Bancomat context)
        {
            Console.WriteLine("Enter 1 if you insert card");
            int ChekCard = Convert.ToInt32(Console.ReadLine());
          
                

                if (ChekCard != 1)
                {
                    context.card = false;
                    context.State = new ErrorCard();
                    return;
                }

            if (ChekCard == 1)
            {
                context.card = true;
                // Изменение состояния системы
                Console.Clear();
                // Изменение состояния системы
                context.State = new EnterPassword();
                return;
            }

          
        }
    
    }
}
