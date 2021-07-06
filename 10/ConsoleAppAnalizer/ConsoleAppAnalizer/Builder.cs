using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAnalizer
{
    // "Product"
    /*class Builder
    {
        List<object> parts = new List<object>();
        // List<Person> parts = new List<Person>();
       // Person person = new Person();
        public void Add(string part)
        {
            parts.Add(part);
        }

        public void ShowSerialized()
        {
            Console.WriteLine("Person serialized -------");
            foreach (string part in parts)
                Console.WriteLine(part);
        }

        public void ShowDeserialized()
        {
            Console.WriteLine("Person deserialized -------");
            foreach (string part in parts)
                Console.WriteLine(part);
        }

    }

    // "Director" 

    class BuilderEditor
    {
       
        Builder bitmap = null;

        public void Load(string filename, IDocumentBuilder builder)
        {
            builder.ReadHeader(filename);
            builder.ReadBody();
            bitmap = builder.GetResult();
        }

        public void Show()
        {
            bitmap?.ShowDeserialized();
            bitmap?.ShowSerialized();
        }
    }

    interface IDocumentBuilder
    {
        void ReadHeader(string filename);
        void ReadBody();
        BitmapDocument GetResult();
    }*/
}
