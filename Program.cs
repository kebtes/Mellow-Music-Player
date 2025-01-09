﻿using System;
using System.Windows.Forms;
using Mellow_Music_Player.UI;
using Mellow_Music_Player.Source.Services.Database_Services;
using Mellow_Music_Player.Source.Services;
using Mellow_Music_Player.Source;
using Mellow_Music_Player.Source.Services.DatabaseServices;
using System.Collections.Generic;

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

            //List<Tuple<Song, Fields>> result = SearchService.Search("Rich");

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Item1.Title);
            //}
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
