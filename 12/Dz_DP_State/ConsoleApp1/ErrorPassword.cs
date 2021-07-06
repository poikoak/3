using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ErrorPassword : State
    {
        public override void Handle(Bancomat context)
        {
            Console.WriteLine("Wrong password!!!");

            context.pass = false;
            // Wait for user 
            Console.Read();
            // Изменение состояния системы
            Console.Clear();
            // Изменение состояния системы
            context.State = new EnterPassword();
        }
    
    }
}
