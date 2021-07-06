using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ex2
{
    class client1
    {
        List<string> lst = new List<string>();
        // обработчик события
        public int EventWriteDictoinary(string str)
        {
            
            string outFileName = str;
            {
                foreach (Match m in Regex.Matches(outFileName, @"\w*ая"))
                {
                    lst.Add("ая");
                    File.WriteAllLines("Dictionary.txt", lst);

                }


                foreach (Match m in Regex.Matches(outFileName, @"\w*ое"))
                {
                    lst.Add("ое");
                    File.WriteAllLines("Dictionary.txt", lst);

                }


                foreach (Match m in Regex.Matches(outFileName, @"\w*ые"))
                {
                    lst.Add("ые");
                    File.WriteAllLines("Dictionary.txt", lst);

                }

                foreach (Match m in Regex.Matches(outFileName, @"\w*ый"))
                {
                    lst.Add("ый");
                    File.WriteAllLines("Dictionary.txt", lst);

                }
            }
            return 0;
        }
    }
}
