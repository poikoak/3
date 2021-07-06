using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleAppAnalizer
{
    class userInterface
    {
        public void Read(Person person)
        {
            // Получить информацию об объекте
            Type objtype = person.GetType();

            // Получить список полей объекта
            FieldInfo[] fields = objtype.GetFields();

            // Перебрать список полей
            foreach (FieldInfo field in fields)
            {
                // Если есть атрибут OpenField
                Attribute openFieldAttr = field.GetCustomAttribute(typeof(Store));
                if (openFieldAttr != null)
                {
                    // Ввод значения с клавиатуры
                    Console.Write("Enter {0}: ", field.Name);
                    string str = Console.ReadLine();

                    // Проверка типов значения
                    if (field.FieldType.Name == "String")
                    {
                        field.SetValue(person, str);
                    }

                    if (field.FieldType.Name == "Int32")
                    {
                        int number = Convert.ToInt32(str);
                        field.SetValue(person, number);
                    }

                    if (field.FieldType.Name == "Double")
                    {
                        double double_number = Convert.ToDouble(str);
                        field.SetValue(person, double_number);
                    }
                }
            }
        }

        public void Write(Person person)
        {
            // Получить информацию об объекте
            Type objtype = person.GetType();

            // Получить список полей объекта
            FieldInfo[] fields = objtype.GetFields();

            // Перебрать список полей
            foreach (FieldInfo field in fields)
            {
                // Если есть атрибут OpenField
                Attribute openFieldAttr = field.GetCustomAttribute(typeof(Store));
                if (openFieldAttr != null)
                {
                    // Вывести информацию из поля
                    Console.WriteLine("{0}: {1}", field.Name, field.GetValue(person));

                }
            }
        }
    }
}

