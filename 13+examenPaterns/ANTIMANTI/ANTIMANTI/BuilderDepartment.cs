using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ANTIMANTI
{

    // "Builder" - задаёт правила для всех построителей
    interface IDocumentBuilder
    {
        void Treatment(object filename);

        BuilderProduct GetResult();
    }

    // "Director" 

    class BuilderDepartment
    {
        // Product - внутренний графический документ редактора
        BuilderProduct bitmap = null;

        public void Treat(object filename, IDocumentBuilder builder)
        {
            builder.Treatment(filename);
           

            bitmap = builder.GetResult();
        }

        public void Show()
        {
            bitmap?.Show();
        }
    }
    class BuilderProduct
    {
        ArrayList points = new ArrayList();

        public void Add(object part)
        {
            points.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nYour chose -------V");
            foreach (string part in points)
                Console.WriteLine(part);
        }
    }

    //////////////////////
    //////////////////////
    ////////////////////// 
    //////////////////////
    // "ConcreteBuilder1" 

    class Delete : IDocumentBuilder
    {
        private BuilderProduct product = new BuilderProduct();

        public void Treatment(object filename)
        {
            product.Add("Infected fails Deleted");
        }      

        public BuilderProduct GetResult()
        {
            return product;
        }
    }

    class Treat : IDocumentBuilder
    {
        private BuilderProduct product = new BuilderProduct();

        public void Treatment(object filename)
        {
            product.Add("Infected fails Treated");
        }

        public BuilderProduct GetResult()
        {
            return product;
        }
    }

    class Ignor : IDocumentBuilder
    {
        private BuilderProduct product = new BuilderProduct();

        public void Treatment(object filename)
        {
            product.Add("Infected fails ignored");
        }

        public BuilderProduct GetResult()
        {
            return product;
        }
    }
}
