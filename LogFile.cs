using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager
{
    internal class LogFile
    {
        public static void Write(string errMessage, string localExeption)
        {
            using (StreamWriter writer = new StreamWriter("Log.txt", append: true))
            {
                writer.Write("[" + DateTime.Now + "]: " + errMessage + " " + localExeption + "\n");
            }
        }
    }
}
