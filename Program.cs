using System;
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
        public async static void lyrics()
        {
            var lyrics = await LyricsService.GetLyrics("The Nights", "Avicii");
            Console.Write(lyrics.ToString());
            lyrics.ForEach(line => Console.WriteLine(line));
        }
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

            lyrics();
            //DatabaseService.AddToPlaylist("Liked Songs", 1);
            settings = new Settings();
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(settings));

            //Console.WriteLine(DatabaseService.GetPlaylists().ToArray()[0].PlaylistName);
            //List<Song> s = DatabaseService.GetPlaylistSongs("Liked Songs");
            //Console.WriteLine(s.Count);
            //Console.WriteLine(DatabaseService.DebugPlaylistSongs());
            //DatabaseService.DebugPlaylistSongs();







        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
