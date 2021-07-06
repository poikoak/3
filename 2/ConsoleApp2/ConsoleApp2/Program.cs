using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp2
{
    class Program
    {
        int outFileNumber = 1;
        void Split(string path)
        {
            Console.WriteLine($"Text are separeted");
            var reader = File.OpenText(path);
            string outFileName = "text.txt.part{0}";
            
            const int MAX_LINES = 5000;
            while (!reader.EndOfStream)
            {
                var writer = File.CreateText(string.Format(outFileName, outFileNumber++));
                for (int idx = 0; idx < MAX_LINES; idx++)
                {
                    writer.WriteLine(reader.ReadLine());

                }
                writer.Close();
            }
            reader.Close();
        }

        void _Return()
        {
            try
            {
                Console.WriteLine($"parts are united");
                FileStream fs_new = new FileStream($"textNEW.txt", FileMode.Create, FileAccess.Write);
                BinaryWriter Bnew = new BinaryWriter(fs_new, Encoding.Default);

                for (int k = 1; k <= outFileNumber; k++)
                {

                    FileStream fs_in_new = new FileStream($"text.txt.part{k}", FileMode.Open, FileAccess.Read);

                    BinaryReader br_in_new = new BinaryReader(fs_in_new, Encoding.Default);

                    byte[] buffer_new = null;
                    buffer_new = br_in_new.ReadBytes((int)fs_in_new.Length);
                    Bnew.Write(buffer_new);
                    fs_in_new.Close();

                }
                fs_new.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"{ex.Message}");
            }
           
        }
        static void Main(string[] args)
        {
            Program st =new Program();  
            string path= "text.txt";
            st.Split(path);
            st._Return();
        }
    }
}
