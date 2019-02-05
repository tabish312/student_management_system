using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace Student_Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Splash());

            /*/ var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            string LastLogin = settings["LastLogin"].Value;

            DateTime dateTime = Convert.ToDateTime(LastLogin);

            if (dateTime > DateTime.Now)
            {
                Application.Run(new FormMain());
            }
            else
            {
                Application.Run(new Splash());
            }/*/


        }
    }
}
