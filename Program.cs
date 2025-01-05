using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mellow_Music_Player.UI;
using Mellow_Music_Player.Source.Services;
using System.Diagnostics;
using Mellow_Music_Player.Source.Models;

namespace Mellow_Music_Player
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            FileService fs = new FileService();
            
            List<Song> songs = fs.getSongs();
            string[] audioFiles = fs.getAudioFiles();


            Console.WriteLine(audioFiles.Length);
            foreach (Song file in fs.getSongs())
            {
                Console.WriteLine(file.Artists[0]);
            }

        }
    }
}
