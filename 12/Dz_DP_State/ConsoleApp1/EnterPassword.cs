using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class EnterPassword : State
    {
        public override void Handle(Bancomat context)
        {
            Console.WriteLine("Enter password from numbers (3487):");          
               int password = Convert.ToInt32(Console.ReadLine());

                if (password != 3487)
                {
                    context.pass = false;
                    context.State = new ErrorPassword();
                    return;
                }

            if (password == 3487)
            {
                Console.WriteLine("Password correct");
                context.pass = true;
                // Изменение состояния системы
                Console.Clear();
                context.State = new Menu();
                return;
            }

           
            




        }
    
    }
}
