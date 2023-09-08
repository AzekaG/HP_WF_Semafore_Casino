using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_WF_Semafore_Casino.Controller
{
    internal class FileWriter           //пока не пишет ничего
    {

        static string path = "Report.txt";
        static public void Writer(List<string> Report)
        {
           
                FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(file);
                foreach (string item in Report)
                {
                    streamWriter.WriteLine(item);
                }
               
                streamWriter.Close();
            


        }


    }
}
