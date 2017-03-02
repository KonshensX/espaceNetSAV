using System;
using System.Windows.Forms;
using System.IO;

namespace espaceNetSAV
{
    static class Program
    {
        //Not used yet
        static string filename = "config.data";
        public static espaceNetSAV.Admin.User _USER ;

        //Getting the configs from the database
        
        public static string _KEY = "ESPACENETSAV";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Initial configuration using the file.
            //Form formObject = new Form();
            //if (CheckForInitialConfiguration()) 
            //{
            //    //This should return true if application needs its initial configuration.
            //    formObject = new Admin.Configuration();
            //}
            //else
            //{
            //    //This will run when the application is already configured.
            //    _USER = new Admin.User();
            //    formObject = new SplashScreen();
            //}

            //End of intial configuration


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
        }

        //public static bool CheckForInitialConfiguration()
        //{
        //    if (File.Exists(filename))
        //    {
        //        BinaryReader br = new BinaryReader(new FileStream(filename, FileMode.Open));


                
        //        return true;

        //    }
        //    return false;
        //}
    }
}
