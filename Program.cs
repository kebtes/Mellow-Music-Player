using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mellow_Music_Player.UI;
using Mellow_Music_Player.Source.Services.Database_Services;
using Mellow_Music_Player.Source.Models;
using System.Data.Entity;
using Mellow_Music_Player.Source.Services;
using Mellow_Music_Player.Source;

namespace Mellow_Music_Player
{
    internal static class Program
    {
        public static Settings settings;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            DatabaseService.InitializeDatabase();
            FileService.Refresh();

            settings = new Settings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(settings));

        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
