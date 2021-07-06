
using System;
using System.Collections.Generic;
using System.IO;

namespace meme
{
    class Save : Attribute { }
    class Program
    {
        static void Main(string[] args)
        {
            Game SpaceJam = new Game("SpaceJam", 2023, 234956654, 1.0);
            Game NeverEnd = new Game("NeverEnd", 2025, 789965654, 2.0);
            Game Summon = new Game("Summon", 2028, 987651654, 6.6);
            Game Test = new Game("Test", 1111, 1111111111, 1.1);
            GamesList games = new GamesList();



     
            DateTime time = new DateTime(2021, 1, 2);
            games.DATA.Add(time, SpaceJam.SaveSettings());
            games.DATA.Add(DateTime.Now, NeverEnd.SaveSettings());
            games.DATA.Add(DateTime.Now, Summon.SaveSettings());

            // Загружаем сохранения (по времени сохраненной версии)
            Test.RestoreSettings(games.DATA[time]);
            Test.Print();
            // Загружаем сохранения (по индексу сохраненной версии)
            Summon.RestoreSettings(games.DATA.Values[1]);
            Summon.Print();

            games.SAVE("GAMES.txt");
        }
    }

    // Memento
    class GameMemento
    {
        public string Game { get; }
        public uint DateReliz { get; }
        public ulong SerialNumber { get; }
        public double Version { get; private set; }     
     
        public GameMemento(string Game, uint DateReliz, ulong SerialNumber, double Version)
        {
            this.Game = Game;
            this.DateReliz = DateReliz;
            this.SerialNumber = SerialNumber;
            this.Version = Version;
           


        }
    }



    // Caretaker
    class GamesList
    {
        public SortedList<DateTime, GameMemento> DATA { get; private set; }

        public GamesList()
        {
            DATA = new SortedList<DateTime, GameMemento>();
        }

        public void SAVE(string path)
        {
            StreamWriter file_out = new StreamWriter(path, false, System.Text.Encoding.Default);
            foreach (var item in this.DATA)
            {
                file_out.WriteLine($"{item.Key}");
                file_out.WriteLine($"Name of the game: {item.Value.Game}");
                file_out.WriteLine($"Year of Reliz: {item.Value.DateReliz}");
                file_out.WriteLine($"Serial number: {item.Value.SerialNumber}");
                file_out.WriteLine($"Version of game: {item.Value.Version}");               
                file_out.WriteLine();
            }
            file_out.Close();
        }
    }

    // Originator
    class Game
    {
        // Модель автомобиля
        [Save]
        string game;
        // Год выпуска
        [Save]
        uint dateReliz;
        // Серийный номер
        [Save]
        ulong serialNumber;
        // Версия ОС
        [Save]
        double version = 1.0;
       
        // Конструктор с обязательными параметрами (модель, год выпуска и серийный номер)
        public Game(string game, uint DateReliz, ulong SerialNumber, double Version)
        {
            this.game = game;
            this.dateReliz = DateReliz;
            this.serialNumber = SerialNumber;
            this.version = Version;
         
        }


        public void Print()
        {
            Console.WriteLine("Name of the game: {0}", game);
            Console.WriteLine("Year of Reliz: {0:D4}", dateReliz);
            Console.WriteLine("Serial Number: {0:D13}", serialNumber);
            Console.WriteLine("Version of game: {0:F2}", version);
           
        }

        // Сохранение состояния
        public GameMemento SaveSettings()
        {
            return new GameMemento(game, dateReliz, serialNumber, version);
        }

        // Восстановление состояния
        public void RestoreSettings(GameMemento memento)
        {
            this.game = memento.Game;
            this.dateReliz = memento.DateReliz;
            this.serialNumber = memento.SerialNumber;
            this.version = memento.Version;
           
        }



    }
}
