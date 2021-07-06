using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
namespace ConsoleAppAnalizer
{
    [Serializable]
    class Store : Attribute
    {

    }
    [Serializable]
    class Person
    {
        [Store]
        public String firstName;

        [Store]
        public String lastName;

        [Store]
        public int age;      

        [Store]
        public double height;



        public Person() { }

        public Person(String firstName, String lastName, int age, double height)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.height = height;
        }

        public void Print()
        {
            Console.WriteLine(@"Name: {0}, LastName: {1}, Age: {2}, Height: {3}", firstName, lastName, age, height);
        }

    }
}
