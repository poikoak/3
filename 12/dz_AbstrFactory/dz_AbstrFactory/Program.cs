using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_AbstrFactory
{
     class Program
    {
        public static void Main(string[] args)
        {
            PacmanFactory game = new CreateGameMap();
            var Ghost1 = game.CreateGhost1();
            var Ghost2 = game.CreateGhost2();
            var Ghost3 = game.CreateGhost3();
            var Pacman = game.CreatePacman();
            Console.WriteLine($"Приветствуем вас {Pacman.Name}, как и всегда вам нужно сьесть все точки");

            Console.WriteLine($"Ого сегодня ваши противники {Ghost1.Name} и {Ghost2.Name}, а так же неповторимый {Ghost3.Name}");

            Pacman.Move();
            Ghost1.Move();
            Ghost2.Move();
            Ghost3.Move();
            Pacman.Eat();
            Pacman.Move();
            Pacman.Eat();
            Pacman.Move();
            Pacman.Eat();
            Pacman.Buf();
            Pacman.Move();
            Pacman.Eat();
            Ghost3.Dead();
            Ghost1.Attack();
            Pacman.Dead();
        }
    }

    interface Сharacter
    {
        string Name { get; }
    }

    interface IPredator : Сharacter
    {
        void Attack();
        void Move();

        void Dead();

    }

    interface IHero : Сharacter
    {
        void Move();
        void Eat();
        void Buf();
        void Dead();
    }

    interface IGhost : IPredator { }
   
    interface IPacman : IHero { }

    class PerpleGhost : IGhost
    {
        public string Name { get; set; } = "PerpleGhost";

        public void Attack()
        {
            Console.WriteLine($"{Name} is attacking ");
        }


        public void Move() 
        {
            Console.WriteLine($"{Name} is Move ");
        }

        public void Dead()
        {
            Console.WriteLine($"{Name} is dead ");
        }
    }

    class BlueGhost : IGhost
    {
        public string Name { get; set; } = "BlueGhost";

        public void Attack()
        {
            Console.WriteLine($"{Name} is attacking ");
        }

        public void Move()
        {
            Console.WriteLine($"{Name} is Move ");
        }
        public void Dead()
        {
            Console.WriteLine($"{Name} is dead ");
        }
    }

    class YelowGhost : IGhost
    {
        public string Name { get; set; } = "YelowGhost";

        public void Attack()
        {
            Console.WriteLine($"{Name} is attacking ");
        }

        public void Move()
        {
            Console.WriteLine($"{Name} is moving");
        }
        public void Dead()
        {
            Console.WriteLine($"{Name} is dead ");
        }
    }

    class Pacman : IPacman
    {
        public string Name { get; set; } = "Pacman";

        public void Move()
        {
            Console.WriteLine($"{Name} is moving ");
        }
        public void Eat()
        {
            Console.WriteLine($"{Name} Waca Waca Waca ");
        }
        public void Buf()
        {
            Console.WriteLine($"{Name} You eat Cherry, now you immortal!!! ");
        }

        public void Dead()
        {
            Console.WriteLine($"{Name} you are deafited");
        }

    }

    abstract class PacmanFactory
    {
        public abstract IGhost CreateGhost1();
        public abstract IGhost CreateGhost2();
        public abstract IGhost CreateGhost3();       
        public abstract IPacman CreatePacman();
    }

   
    class CreateGameMap : PacmanFactory
    {
        public override IGhost CreateGhost1()
        {
            return new YelowGhost();
            
        }

        public override IGhost CreateGhost2()
        {
            return new BlueGhost();

        }

        public override IGhost CreateGhost3()
        {
            return new PerpleGhost();

        }

       
        public override IPacman CreatePacman()
        {
            return new Pacman();

        }
    }
}
