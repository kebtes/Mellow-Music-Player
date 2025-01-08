using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TagLib;

using Mellow_Music_Player.Source;
using Mellow_Music_Player.Source.Models;
using Mellow_Music_Player.Source.Services.Database_Services;


namespace Mellow_Music_Player.Source.Services
{
    public static class FileService
    {
        private static string directory = Settings.songsDirectory;
        private static List<Song> songs = new List<Song>();

        private static string[] audioFiles;

        public static void Refresh() 
        {   
            try
            {
                audioFiles = Directory.GetFiles(directory, "*.mp3", SearchOption.TopDirectoryOnly);
            } catch (FileNotFoundException e)
            {
                Debug.WriteLine("Error while trying to access path in FileService" + e);
            }

           
            foreach (string file in audioFiles)
            {
                try
                {
                    Song song = new Song();

                    // Create the TagLib file here to access the metadata
                    using (TagLib.File tagFile = TagLib.File.Create(file))
                    {
                        song.Title = tagFile.Tag.Title ?? Path.GetFileNameWithoutExtension(file);
                        song.Album = tagFile.Tag.Album ?? "";
                        song.Artists = tagFile.Tag.AlbumArtists?.Length > 0 ? tagFile.Tag.AlbumArtists : new string[] { "Unknown Artist" };
                        song.Genres = tagFile.Tag.Genres?.Length > 0 ? tagFile.Tag.Genres : new string[] { "Unknown Genre" };
                        song.Duration = tagFile.Properties.Duration;

                        if (tagFile.Tag.Pictures.Length > 0)
                        {
                            var bin = tagFile.Tag.Pictures[0].Data.Data;
                            using (MemoryStream ms = new MemoryStream(bin))
                            {
                                song.AlbumArt = Image.FromStream(ms);
                            }
                        }

                        song.FilePath = file;
                        songs.Add(song);

                        DatabaseService.AddSongToTable(song);
                    }

                } 
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {file}: {ex.Message}");
                    continue;
                }
        
            }

        }

        public static string[] getAudioFiles()
        {
            return audioFiles;
        }

        public static List<Song> getSongs()
        {
            return songs;
        }

        public static Image GetAlbumArt(string path)
        {
            using (TagLib.File tagFile = TagLib.File.Create(path))
            {
                if (tagFile.Tag.Pictures.Length > 0)
                {
                    var bin = tagFile.Tag.Pictures[0].Data.Data;
                    using (MemoryStream ms = new MemoryStream(bin))
                    {
                        return Image.FromStream(ms); ;
                    }
                }
            }

            return null;
        }
    }
}
