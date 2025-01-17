using Mellow_Music_Player.Source.Services.Database_Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Mellow_Music_Player.Source.Services
{
    public static class FileService
    {
        private static string directory;
        private static List<Song> songs ;

        private static string[] audioFiles;

        public static void Refresh()
        {
            try
            {
                songs = new List<Song>();
                directory = Settings.SongsDirectory;

                if (directory == null)
                {
                    return;
                }

                audioFiles = Directory.GetFiles(directory, "*.mp3", SearchOption.TopDirectoryOnly);
            }
            catch (FileNotFoundException e)
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

        public static string[] GetAudioFiles()
        {
            return audioFiles;
        }

        public static List<Song> GetSongs()
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
