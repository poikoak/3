//2.Реализовать паттерн Memento для системы резервного копирования. Требования к системе:
//-класс Memento(контейнер) позволяет хранить различные свойства в любом количестве, разных типов,
//является универсальным
//- хранилище позволяет хранить много копий контейнеров
//- из хранилища можно извлекать контейнеры по номеру
//- из хранилища можно извлекать контейнеры по дате и времени сохранения
//- хранилище можно сгрузить в файл

using System;
using System.Collections.Generic;
using System.IO;

namespace UMementoClass
{
    class Save : Attribute { }
    class Program
    {
        static void Main(string[] args)
        {
            Tesla car = new Tesla("T", 2019, 4965137956654, 1.0, 23);
            Tesla car2 = new Tesla("D", 2020, 0000000000000, 0.0, 0);
            Tesla car3 = new Tesla("A", 2021, 0000000000000, 0.0, 0);
            Tesla car4 = new Tesla("S", 2021, 0000000000000, 0.0, 0);
            CarsHistory cars = new CarsHistory();

            // Сохраняем настройки
            DateTime time = new DateTime(2021, 7, 20, 18, 30, 25);
            cars.history.Add(time, car.SaveSettings());
            cars.history.Add(DateTime.Now, car2.SaveSettings());

            // Загружаем настройки в другой автомобиль (по времени сохраненной версии)
            car2.RestoreSettings(cars.history[time]);
            car2.Print();

            // Загружаем настройки в другой автомобиль (по индексу сохраненной версии)
            car3.RestoreSettings(cars.history.Values[1]);
            car3.Print();

            // Сохранение настроек автомобиля в файл
            cars.SaveToFile("cars.dat");
        }
    }

    // Memento
    class CarMemento
    {
        public string Model { get; }
        public uint Year { get; }
        public ulong Serial_number { get; }
        public double VerOS { get; private set; }
        public uint Mileage { get; private set; }
        public ushort Battery_charge { get; private set; }
        public uint Speed_limit { get; private set; }
        public CarMemento(string model, uint year, ulong serial_number, double verOS, uint mileage, ushort battery_charge = 100, uint speed_limit = 140)
        {
            this.Model = model;
            this.Year = year;
            this.Serial_number = serial_number;
            this.VerOS = verOS;
            this.Mileage = mileage;
            this.Battery_charge = battery_charge;
            this.Speed_limit = speed_limit;


        }
    }



    // Caretaker
    class CarsHistory
    {
        public SortedList<DateTime, CarMemento> history { get; private set; }
        
        public CarsHistory() 
        {
            history = new SortedList<DateTime, CarMemento>();
        }

        public void SaveToFile(string path)
        {
            StreamWriter file_out = new StreamWriter(path, false, System.Text.Encoding.Default);
            foreach (var item in this.history)
            {
                file_out.WriteLine($"{item.Key}");
                file_out.WriteLine($"Model: {item.Value.Model}");
                file_out.WriteLine($"Year: {item.Value.Year}");
                file_out.WriteLine($"Serial number: {item.Value.Serial_number}");
                file_out.WriteLine($"VerOs: {item.Value.VerOS}");
                file_out.WriteLine($"Mileage: {item.Value.Mileage}");
                file_out.WriteLine($"Battery charge: {item.Value.Battery_charge}");
                file_out.WriteLine($"Speed limit: {item.Value.Speed_limit}");
                file_out.WriteLine();
            }
            file_out.Close();
        }
    }

    // Originator
    class Tesla
    {
        // Модель автомобиля
        [Save]
        string model;
        // Год выпуска
        [Save]
        uint year;
        // Серийный номер
        [Save]
        ulong serial_number;
        // Версия ОС
        [Save]
        double verOS = 1.0;
        // Пробег
        [Save]
        uint mileage = 0;
        // Заряд аккумулятора
        [Save]
        ushort battery_charge = 100;
        // Установленный ограничитель скорости
        [Save]
        uint speed_limit = 120;

        // Конструктор с обязательными параметрами (модель, год выпуска и серийный номер)
        public Tesla(string model, uint year, ulong serial_number, double verOS, uint mileage, ushort battery_charge = 100, uint speed_limit = 140)
        {
            this.model = model;
            this.year = year;
            this.serial_number = serial_number;
            this.verOS = verOS;
            this.mileage = mileage;
            this.battery_charge = battery_charge;
            this.speed_limit = speed_limit;
        }


        public void Print()
        {
            Console.WriteLine("Model: {0}", model);
            Console.WriteLine("Year: {0:D4}", year);
            Console.WriteLine("Serial Number: {0:D13}", serial_number);
            Console.WriteLine("Version OS: {0:F2}", verOS);
            Console.WriteLine("Mileage: {0}", mileage);
            Console.WriteLine("SpeedLimit: {0}", speed_limit);
            Console.WriteLine("Battery Charge: {0}\n", battery_charge);
        }

        // Сохранение состояния
        public CarMemento SaveSettings()
        {
            return new CarMemento(model, year, serial_number, verOS, mileage, battery_charge = 100, speed_limit = 140);
        }

        // Восстановление состояния
        public void RestoreSettings(CarMemento memento)
        {
            this.model = memento.Model;
            this.year = memento.Year;
            this.serial_number = memento.Serial_number;
            this.verOS = memento.VerOS;
            this.mileage = memento.Mileage;
            this.speed_limit = memento.Speed_limit;
            this.battery_charge = memento.Battery_charge;
            this.speed_limit = memento.Speed_limit;
        }

        

    }
}
