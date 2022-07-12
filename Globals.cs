using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager
{
    public class Globals
    {
        public static string BenchName { get; set; }
        public static string DataAdressSN { get; set; }
        public static string DataAdressUT { get; set; }
        public static string DataAdressUM { get; set; }

        public static Microsoft.Office.Interop.Excel.Application xlapp { get; set; }
    }
}
