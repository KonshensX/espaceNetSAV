using System;
using System.Windows.Forms;
using System.IO;

namespace espaceNetSAV
{
    static class Program
    {
        //Not used yet
        static string filename = "config.data";
        public static espaceNetSAV.Admin.User _USER = new Admin.User();

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
            /*if (CheckForInitialConfiguration()) 
            {
                //This means the file doesn't have any value there for display the configuration form for the user
                //formObject = new Admin.Configuration();
            }
            else
            {
                //This means the application is already configured 
                //This will run when the application is already configured.
                //_USER = new Admin.User();
                //formObject = new SplashScreen();
            }*/

            //End of intial configuration


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
        }

        public static bool CheckForInitialConfiguration()
        {
            
            try
            {
                if (File.Exists(filename))
                {
                    using (BinaryReader br = new BinaryReader(new FileStream(filename, FileMode.Open)))
                    {
                        var result = br.ReadString();
                        while (result != null)
                        {
                            //This means that the file has values
                            return true;
                        }
                    }
                }
                //This means the file doesn't have any values
                return false;
            }
            finally
            {
                Console.WriteLine("Was done!");
            }
            //return false;
        }
    }
}
