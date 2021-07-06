using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS_OPERATOR_counter
{
    class Program
    {
        public void ForSearch(string s, ref int c2)
        {
            int indexF = s.IndexOf("for (");
            if (indexF != -1)
            {
              
                c2++;
                Console.WriteLine($"\noperator 'for' found in string /{s}/----- FOR-COUNTER= {c2}");
            }
        }

        public void IfSearch(string s, ref int c1)
        {
            int indexI = s.IndexOf("if (");
            if (indexI != -1)
            {
                c1++;
                Console.WriteLine($"\noperator 'if' found in string /{s}/----- IF-COUNTER= {c1}");
            }
        }

        public void VarSearch(string s, List<string> VN, ref int c3)
        {
            s=s.TrimStart();
            
            if (s.StartsWith("public")==true || s.StartsWith("private") == true || s.StartsWith("static") == true || s.StartsWith("void") == true)
            {
                //Console.WriteLine(s);
                foreach (string l in VN)
                {
                    int index = s.IndexOf(l);
                    if (index != -1)
                    {
                        if (Char.IsLetterOrDigit(s[index - 1]) == false)
                        {
                            c3++;
                            Console.WriteLine($"\nSpecial search result: variable {l} found in string /{s}/ ----- VAR-COUNTER= {c3}");
                            index += l.Length;

                            while (Char.IsLetterOrDigit(s[index]) == true)
                            {
                                index++;
                            }

                            if (s[index] == ',' || (s[index] == ' ' && s[index + 1] == ','))
                            {
                                string temp = s.Substring(index);
                                int index1 = temp.IndexOf(l);
                                while (index1 != -1)
                                {
                                    c3++;
                                    Console.WriteLine($"\nSubsearch result: variable {l} found in string /{temp}/ ----- VAR-COUNTER= {c3}");
                                    temp = temp.Substring(index1 + l.Length);
                                    index1 = temp.IndexOf(l);
                                }
                                
                            }

                        }
                    }
                }
            }

            else
            {
                foreach (string l in VN)
                {
                    int index = s.IndexOf(l);
                    if (index != -1)
                    {
                        if (index != 0)
                        {
                            if (Char.IsLetterOrDigit(s[index - 1]) == false)
                            {
                                c3++;
                                Console.WriteLine($"\nvariable {l} found in string /{s}/ ----- VAR-COUNTER= {c3}");
                                index += l.Length;

                                while (Char.IsLetterOrDigit(s[index]) == true)
                                {
                                    index++;
                                }

                                if (s[index] == ',' || (s[index] == ' ' && s[index + 1] == ','))
                                {
                                    c3++;
                                    Console.WriteLine($"\nvariable {l} found in string /{s}/ ----- VAR-COUNTER= {c3}");
                                    while (index < s.Length - 1 && (s[index] != '=' || s[index] != ';'))
                                    {

                                        index++;

                                        if (s[index] == ',')
                                        {
                                            c3++;
                                           Console.WriteLine($"\nvariable {l} found in string /{s}/ ----- VAR-COUNTER= {c3}");
                                        }
                                    }
                                }
                                else if (s[index] == '=' || (s[index] == ' ' && s[index + 1] == '='))
                                {
                                    while (index < s.Length - 1 && (s[index] != ';'))
                                    {

                                        index++;

                                        if (s[index] == '"')
                                        {
                                            index++;
                                            while (s[index] != '"')
                                            {
                                                index++;
                                            }
                                        }
                                        if (s[index] == '(')
                                        {
                                            index++;
                                            while (s[index] != ')')
                                            {
                                                index++;
                                            }
                                        }

                                        if (s[index] == '{')
                                        {
                                            index++;
                                            while (s[index] != '}')
                                            {
                                                index++;
                                            }
                                        }

                                        if (s[index] == ',')
                                        {
                                            c3++;
                                            Console.WriteLine($"\nvariable {l} found in string /{s}/ ----- VAR-COUNTER= {c3}");
                                        }
                                    }
                                }
                            }



                        }

                        else
                        {
                            c3++;
                            Console.WriteLine($"\nvariable {l} found in string /{s}/ ----- VAR-COUNTER= {c3}");
                            index += l.Length;

                            while (Char.IsLetterOrDigit(s[index]) == true)
                            {
                                index++;
                            }

                            if (s[index] == ',' || (s[index] == ' ' && s[index + 1] == ','))
                            {
                                c3++;
                                Console.WriteLine($"\nvariable {l} found in string /{s}/ ----- VAR-COUNTER={c3}");
                                while (index < s.Length - 1 && (s[index] != '=' || s[index] != ';'))
                                {

                                    index++;

                                    if (s[index] == ',')
                                    {
                                        c3++;
                                        Console.WriteLine($"\nvariable {l} found in string /{s}/ ----- VAR-COUNTER= {c3}");
                                    }
                                }
                            }
                            else if (s[index] == '=' || (s[index] == ' ' && s[index + 1] == '='))
                            {
                               
                                while (index < s.Length - 1 && (s[index] != ';'))
                                {

                                    index++;

                                    if (s[index] == '"')
                                    {
                                        index++;
                                        while (s[index] != '"')
                                        {
                                            index++;
                                        }
                                    }
                                    if (s[index] == '(')
                                    {
                                        index++;
                                        while (s[index] != ')')
                                        {
                                            index++;
                                        }
                                    }

                                    if (s[index] == '{')
                                    {
                                        index++;
                                        while (s[index] != '}')
                                        {
                                            index++;
                                        }
                                    }

                                    if (s[index] == ',')
                                    {
                                        c3++;
                                        Console.WriteLine($"\nvariable {l} found in string /{s}/ ----- VAR-COUNTER= {c3}");
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }
        
        public void FindFiles(string path, ref List<string> list)
        {
            DirectoryInfo d1 = new DirectoryInfo($"{path}");
            if (d1.Exists == true)
            {
                FileInfo[] files1 = d1.GetFiles("*.cs");
                foreach (FileInfo current in files1)
                {
                    list.Add(current.FullName);
                }

            }
            else Console.WriteLine("Incorrect path entered!");

        }
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Enter folder path: ");
                string dir = Console.ReadLine();
                Console.WriteLine($"\n{dir}");
                args = new string[] { dir };
            }

            int n = args[0].LastIndexOf('\\');
            string f = args[0].Substring(n+1);
            string path = args[0] + "\\" + f + "\\";
            Console.WriteLine($"\n{path}");

            List<string> list = new List<string>();

            Program p = new Program();
            p.FindFiles(path, ref list);


            List<string> code = new List<string>();

            foreach (string filename in list)
            {
                try
                {
                    Console.WriteLine($"\n{filename}");
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
                    
                    List<string> VN = new List<string>();
                    VN.Add("int ");
                    VN.Add("int[] ");
                    VN.Add("int[][] ");
                    VN.Add("long ");
                    VN.Add("long[] ");
                    VN.Add("long[][] ");
                    VN.Add("float ");
                    VN.Add("float[] ");
                    VN.Add("float[][] ");
                    VN.Add("double ");
                    VN.Add("double[] ");
                    VN.Add("double[][] ");
                    VN.Add("bool ");
                    VN.Add("bool[] ");
                    VN.Add("string ");
                    VN.Add("string[] ");
                    VN.Add("byte ");
                    VN.Add("byte[] ");
                    VN.Add("decimal ");
                    VN.Add("decimal[] ");
                    VN.Add("short ");
                    VN.Add("short[] ");
                    VN.Add("short[][] ");
                    VN.Add("sbyte ");
                    VN.Add("sbyte[] ");
                    VN.Add("var ");
                    VN.Add("Object ");
                    VN.Add("Object[] ");
                    VN.Add("char ");
                    VN.Add("char[] ");

                    int c1 = 0;
                    int c2 = 0;
                    int c3 = 0;

                    Console.WriteLine($"\n{code.Count}\n\n");
                    int num = 1;
                    for (int j = 0; j < code.Count; j++)
                    {
                        if (code[j] != null)
                        {
                            
                            num++;

                            p.IfSearch(code[j], ref c1);
                            p.ForSearch(code[j], ref c2);
                            p.VarSearch(code[j], VN, ref c3);

                        }
                    }
                    
                    Console.WriteLine($"\nIn the code of programme '{f}' there are: \n  {c1} operators 'if', \n  {c2} operators 'for', \n  {c3} variables.");
                    
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}



