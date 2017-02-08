using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espaceNetSAV
{
    static class Program
    {
        public static espaceNetSAV.Admin.User _USER;
        public static string _KEY = "ESPACENETSAV";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GridTesting());
        }
    }
}
