using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS_Code_Editor
{
    class Program
    {
        public void EditString(ref List<string> code)
        {
            Console.WriteLine($"\nEditing {code.Count} lines from current file\n\n"  );
            for (int j = 0; j < code.Count; j++)
            {
                string temp = null;
                Console.WriteLine($"\nEditing line {j+1}: ----- {code[j]}\n\n");
                if (code[j] != null)
                {

                    //temp = code[j];
                    // Console.WriteLine($"\nThis is the initial line:------------------------------------------------");
                    // Console.WriteLine($"\n{temp}");
                    char[] arr = new char[code[j].Length + 1];
                    arr=code[j].ToCharArray();
                    //temp = null;
                    int tabCount = 0;

                    Console.WriteLine(arr.Length);
                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.WriteLine(i+ " "+arr[i] );
                        if (arr[i] == '#' && i!=0 && arr[i-1]!='\n')
                        {
                            temp += "\r\n";
                            temp += arr[i];
                        }
                        else if (arr[i] == ';')
                        {
                            temp += arr[i];
                            if (i != arr.Length - 1)
                            {
                                if (arr[i + 1] != '\r') temp += "\r\n";
                                for (int k = 0; k < tabCount; k++)
                                {
                                    if (arr[i + 1 + k] != '\t')
                                        temp += "\t";
                                }
                            }

                        }
                        else if (arr[i] == '{')
                        {
                            if (i != 0)
                            {
                                if (arr[i - 1] != '\n') temp += "\r\n";
                                for (int k = 0; k < tabCount; k++)
                                {
                                    //if (arr[i + 1 + k] != '\t') 
                                    temp += "\t";
                                }
                            }
                            temp += arr[i];
                            tabCount++;

                            if (i != arr.Length - 1)
                            {
                                if (arr[i + 1] != '\r') temp += "\r\n";
                                for (int k = 0; k < tabCount; k++)
                                {
                                    if (arr[i + 1 + k] != '\t')
                                        temp += "\t";
                                }
                            }
                            
                        }
                        else if (arr[i] == '}')
                        {
                            if (i != 0)
                            {
                                if (arr[i - 1] != '\n')
                                    temp += "\r\n";
                                tabCount--;
                                for (int k = 0; k < tabCount; k++)
                                {
                                    //if (arr[i + 1 + k] != '\t') 
                                    temp += "\t";
                                }
                            }
                            temp += arr[i];
                            if (i != arr.Length - 1)
                            {
                                temp += "\r\n";

                                for (int k = 0; k < tabCount; k++)
                                {
                                    if (i != arr.Length - 1)
                                    {
                                        if (arr[i + 1 + k] != '\t')
                                            temp += "\t";
                                    }
                                }
                            }
                        }
                        else if (arr[i] == 'u' && arr[i + 1] == 's' && arr[i + 2] == 'i' && arr[i + 3] == 'n' && arr[i + 4] == 'g' && arr[i + 5] == ' ')
                        {
                            if (i != 0)

                            {
                                if (arr[i - 1] != '\n')
                                {
                                    temp += "\r\n";
                                    
                                }
                            }
                            
                            temp += arr[i];

                        }
                        else if (arr[i] == 'f' && arr[i + 1] == 'o' && arr[i + 2] == 'r' && arr[i + 3] == ' ' && arr[i + 4] == '(')
                        {
                            while (arr[i] != ')')
                            {
                                temp += arr[i];
                                i++;
                            }
                            temp += arr[i];

                        }
                        else
                        {
                            temp += arr[i];
                        }

                    }
                   // Console.WriteLine($"\nThis is the edited line:------------------------------------------------");
                   Console.WriteLine($"\n{temp}");
                    code[j] = null;
                    code[j] = temp;
                }
            }

            Console.WriteLine($"\nEditing lines completed\n\n");

        }

        public void FindFiles(string path, ref List<string> list)
        {
            Console.WriteLine("\nFinding files");
            DirectoryInfo d1 = new DirectoryInfo($"{path}");
            if (d1.Exists == true)
            {
                FileInfo[] files = d1.GetFiles("*.cpp");
                foreach (FileInfo current in files)
                {
                    list.Add(current.FullName);
                }

                FileInfo[] files1 = d1.GetFiles("*.cs");
                foreach (FileInfo current in files1)
                {
                    list.Add(current.FullName);
                }

                FileInfo[] files2 = d1.GetFiles("*.h");
                foreach (FileInfo current in files2)
                {
                    list.Add(current.FullName);
                }
                Console.WriteLine("\nFinding files completed");
            }
            else Console.WriteLine("Incorrect path entered!");

        }
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Enter folder path: ");
                string dir = Console.ReadLine();
                //Console.WriteLine($"\n{dir}");
                args = new string[] { dir };
            }

            int n = args[0].LastIndexOf('\\');
            string f = args[0].Substring(n);
            string path = args[0] + "\\" + f + "\\";
            //Console.WriteLine($"\n{path}");

            List<string> list = new List<string>();

            Program p = new Program();
            p.FindFiles(path, ref list);


            List<string> code = new List<string>();

            foreach (string filename in list)
            {
                try
                {
                    Console.WriteLine($"\nEliciting lines from file: {filename}");
                    StreamReader stream = new StreamReader(filename, Encoding.Default);
                    string line = null;
                    line = stream.ReadLine();
                    code.Add(line);

                    while (line != null)
                    {

                        line = stream.ReadLine();
                        code.Add(line);
                    }
                    stream.Close();
                    Console.WriteLine($"\nEliciting lines completed");
                    // Console.WriteLine($"\nThis is the initial text:");
                    //foreach (string l in code)
                    //{
                    //    Console.WriteLine($"\n{l}");
                    //}


                    p.EditString(ref code);
                    Console.WriteLine($"\nThis is the edited text:");
                    foreach (string l in code)
                    {
                        Console.WriteLine($"\n{l}");
                    }
                    Console.WriteLine($"Recording edited lines back into original file {filename}");
                    StreamWriter writer = new StreamWriter($"{filename}", false, Encoding.Default);
                    foreach (string l in code)
                    {
                        writer.WriteLine($"{l}");
                    }
                    writer.Close();
                    Console.WriteLine($"Recording completed");
                    code.Clear();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
