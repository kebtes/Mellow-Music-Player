using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Mellow_Music_Player.Source.Services.Database_Services
{
    public static class DatabaseService
    {
        private static readonly string connectionString = Constant.DBConnectionString;

        public static void InitializeDatabase()
        {
            string dbFilePath = Constant.DBFilePath;
            //MessageBox.Show(File.Exists(dbFilePath).ToString());

            if (!File.Exists(dbFilePath))
            {
                using (FileStream fs = File.Create(dbFilePath)) { }

            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(Queries.CheckSongTable, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result == null)
                    {
                        string[] createTables = { Queries.SongTables, Queries.PlaylistTable, Queries.PlaylistSongsTable };

                        foreach (var item in createTables)
                        {
                            using (var createCommand = new SQLiteCommand(item, connection))
                            {
                                createCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            
        }

        public static void PurgeTables()
        {
            ClearPlaylistSongsTable();
            ClearPlaylistTable();
            ClearSongsTable();
        }

        public static void ClearSongsTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(Queries.DeleteSongTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public static void ClearPlaylistTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(Queries.DeletePlaylistTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ClearPlaylistSongsTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(Queries.DeletePlaylistSongsTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public static void AddSongToTable(Song song)
        {
            if (SongExists(song)) return;
            
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(Queries.AddSong, connection))
                    {
                        string artistsJoined = string.Join(" ", song.Artists);
                        string genresJoined = string.Join(" ", song.Genres);

                        cmd.Parameters.AddWithValue("@title", song.Title);
                        cmd.Parameters.AddWithValue("@artist", artistsJoined);
                        cmd.Parameters.AddWithValue("@album", song.Album);
                        cmd.Parameters.AddWithValue("@genre", genresJoined);
                        cmd.Parameters.AddWithValue("@duration", song.Duration.TotalSeconds);
                        cmd.Parameters.AddWithValue("@filePath", song.FilePath);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        public static List<Song> GetSongs()
        {
            List<Song> songs = new List<Song>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(Queries.GetSongs, connection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string filePath = reader.GetString(5);
                                Song song = new Song();

                                song.Title = reader.GetString(0);
                                song.Artists = reader.GetString(1).Split(' ');
                                song.Album = reader.GetString(2);
                                song.Genres = reader.GetString(3).Split(' ');
                                song.Duration = TimeSpan.FromSeconds(reader.GetDouble(4)); 

                                song.FilePath = filePath;
                                song.AlbumArt = FileService.GetAlbumArt(filePath);
                                

                                songs.Add(song);
                            }
                        }
                    }
                }
            }

            catch (SQLiteException ex)
            {
                {
                    Debug.WriteLine($"Error fetching songs from database {ex.Message}");
                }

            }
            
            return songs;
        }

        public static bool SongExists(Song song)
        {
            string filePath = song.FilePath;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(Queries.CheckSongExists, connection))
                    {
                        cmd.Parameters.AddWithValue("@filePath", filePath);

                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (SQLiteException e) 
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
