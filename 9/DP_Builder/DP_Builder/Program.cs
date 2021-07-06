using System;
using System.Collections;

namespace Builder
{
    public class MainApp
    {
        public static void Main()
        {
            // класс-пользователь построителей
            GraphicsEditor editor = new GraphicsEditor();

            IDocumentBuilder b1 = new DOC();
            IDocumentBuilder b2 = new DOCX();
            IDocumentBuilder b3 = new PDF();

            // загрузка внешнего файла и построение внутренного документа
            editor.Load(@"c:\1.DOC", b1);

            // Использование построенного документа
            editor.Show();

            editor.Load(@"c:\2.DOCX", b2);
            editor.Show();
            editor.Load(@"c:\3.PDF", b2);
            editor.Show();
            // Wait for user 
            Console.Read();
        }
    }

    // "Director" 

    class GraphicsEditor
    {
        // Product - внутренний графический документ редактора
        BitmapDocument bitmap = null;

        public void Load(string filename, IDocumentBuilder builder)
        {
            builder.ReadHeader(filename);
            builder.ReadBody();

            bitmap = builder.GetResult();
        }

        public void Show()
        {
            bitmap?.Show();
        }
    }

    // "Builder" - задаёт правила для всех построителей
    interface IDocumentBuilder
    {
        void ReadHeader(string filename);
        void ReadBody();
        BitmapDocument GetResult();
    }

    // "ConcreteBuilder1" 

    class DOC : IDocumentBuilder
    {
        private BitmapDocument product = new BitmapDocument();

        public void ReadHeader(string filename)
        {
            product.Add("DOC Header");
        }

        public void ReadBody()
        {
            product.Add("DOC text");
        }

        public BitmapDocument GetResult()
        {
            return product;
        }
    }

    // "ConcreteBuilder2" 

    class DOCX : IDocumentBuilder
    {
        private BitmapDocument product = new BitmapDocument();

        public void ReadHeader(string filename)
        {
            product.Add("DOCX Header");
        }

        public void ReadBody()
        {
            product.Add("DOCX TEXT");
        }

        public BitmapDocument GetResult()
        {
            return product;
        }
    }

    class PDF : IDocumentBuilder
    {
        private BitmapDocument product = new BitmapDocument();

        public void ReadHeader(string filename)
        {
            product.Add("PDF Header");
        }

        public void ReadBody()
        {
            product.Add("PDF TEXT");
        }

        public BitmapDocument GetResult()
        {
            return product;
        }
    }

    // "Product"
    class BitmapDocument
    {
        ArrayList points = new ArrayList();

        public void Add(string part)
        {
            points.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nProduct Parts -------");
            foreach (string part in points)
                Console.WriteLine(part);
        }
    }
}
