using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ex2
{
    class client2
    {
      
        // обработчик события    
        public int EventSaveLog(string str)
        {
            string infile = str;
            StreamWriter file_out = new StreamWriter("LOG.txt", true, System.Text.Encoding.Default);
            
                file_out.WriteLine(DateTime.Now);
                file_out.WriteLine(infile);                
                file_out.WriteLine();
            
            file_out.Close();
            return 0;
        }

    }

    
}
