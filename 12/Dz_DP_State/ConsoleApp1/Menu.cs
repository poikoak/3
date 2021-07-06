using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Menu : State
    {
        static public string Comand;

        public override void Handle(Bancomat context)
        {


            Console.Clear();
                Console.WriteLine("Choose one of the following options:\n");
                Console.WriteLine("1. View balance");
                Console.WriteLine("****************");
                Console.WriteLine("2. Amount selection ");
                Console.WriteLine("****************");
                Console.WriteLine("3. Deposit ");
                Console.WriteLine("****************");
                Console.WriteLine("4. Exit ");
                Comand = Console.ReadLine();

                if (Comand == "1")
                {

                    Console.Clear();
                    Console.WriteLine(" View balance");
                    context.State = new BallanceOnTheCard();
                    return;
                }

                else if (Comand == "2")
                {
                    Console.Clear();
                    Console.WriteLine(" Amount selection");
                    context.State = new AmountSelection();
                    return;
                }
                else if (Comand == "3")
                {
                    Console.Clear();
                    Console.WriteLine(" Deposit");
                    context.State = new CardDeposit();
                    return;
                }

                else if (Comand == "4")
                {
                    Environment.Exit(0);
                }
                /*else if (Comand != "1"|| Comand != "2" || Comand != "3" || Comand != "4")
                {
                    Console.WriteLine("Wrong data..");
                // Wait for user 
                Console.Read();
                Console.Clear();

                }*/
            



            /*    case 1:
                    Console.Clear();
        Console.WriteLine("View balance \n");
        context.State = new BallanceOnTheCard();
        return;

                case 2:
                    Console.Clear();
        Console.WriteLine("Amount selection \n");
        context.State = new AmountSelection();
        return;

                case 3:
                    Console.Clear();
        Console.WriteLine(" Deposit \n");
        context.State = new CardDeposit();
        return;

                case 4:
                    Console.WriteLine(" Exit \n");
        Environment.Exit(0);
        break;
        default:
                    Console.Read();
        break;*/

        }
    }
}
            
 
