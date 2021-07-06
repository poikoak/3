using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
                // Создание системы, основанной на состояниях и установка начального состояния
                Bancomat banc = new Bancomat(new WaitForCreditCard());

                banc.Start();

                // Wait for user 
                Console.Read();
            
        }
    }
    abstract class State
    {
        // Метод меняет одно состояние на другое
        public abstract void Handle(Bancomat context);
    }
}
