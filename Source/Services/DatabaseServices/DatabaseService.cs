using Mellow_Music_Player.Source.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
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

        public static int GetPlaylistId(string playlistName)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(Queries.GetPlaylistID, connection))
                    {
                        cmd.Parameters.AddWithValue("@playlistName", playlistName);
                        return Convert.ToInt32(cmd.ExecuteScalar());
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

            return 0;
        }

        private static int GetSongId(string filePath)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(Queries.GetSongIdByFilePath, connection))
                    {
                        cmd.Parameters.AddWithValue("@filePath", filePath);
                        return Convert.ToInt32(cmd.ExecuteScalar());
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
            return 0;
        }

        public static void AddToPlaylist(string playlistName, Song song)
        {
            int songId = GetSongId(song.FilePath);
            int playlistId = GetPlaylistId(playlistName);
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(Queries.InsertIntoPlaylist, connection))
                    {
                        cmd.Parameters.AddWithValue("@playlistId", playlistId);
                        cmd.Parameters.AddWithValue("@songId", songId);
                        cmd.ExecuteNonQuery();
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
        }

        public static List<Song> GetPlaylistSongs(string playlistName)
        {
            List<Song> playlistSongs = new List<Song>();

            int playlistId = GetPlaylistId(playlistName);

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(Queries.GetPlayListSongsById, connection))
                    {
                        cmd.Parameters.AddWithValue("@playlistID", playlistId);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Song song = new Song();

                                song.Title = reader.GetString(1);
                                song.Artists = reader.GetString(2).Split(' ');
                                song.Album = reader.GetString(3);
                                song.Genres = reader.GetString(4).Split(' ');
                                song.Duration = TimeSpan.FromSeconds(reader.GetDouble(5));
                                song.FilePath = reader.GetString(6);

                                if (!string.IsNullOrEmpty(song.FilePath) && System.IO.File.Exists(song.FilePath))
                                {
                                    TagLib.File file = TagLib.File.Create(song.FilePath);
                                    if (file.Tag.Pictures.Length > 0)
                                    {
                                        var bin = file.Tag.Pictures[0].Data.Data;
                                        using (MemoryStream ms = new MemoryStream(bin))
                                        {
                                            song.AlbumArt = Image.FromStream(ms);
                                        }
                                    }
                                    else
                                    {
                                        song.AlbumArt = null;
                                    }
                                }

                                playlistSongs.Add(song);


                            }
                        }
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

            return playlistSongs;

        }

        public static List<Playlist> GetPlaylists()
        {
            List<Playlist> playlists = new List<Playlist>();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(Queries.GetPlaylists, connection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                playlists.Add(new Playlist
                                {
                                    PlaylistId = reader.GetInt32(0),
                                    PlaylistName = reader.GetString(1),
                                    PlaylistColor = reader.GetString(2),
                                    CreatedAt = reader.GetDateTime(3)
                                });

                            }
                        }
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

            return playlists;
        }

        public static bool IsSongInPlaylist(string playlistName, Song song)
        {
            int playlistId = GetPlaylistId(playlistName);
            int songId = GetSongId(song.FilePath);

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(Queries.CheckSongInPlaylist, connection))
                    {
                        cmd.Parameters.AddWithValue("@playlistID", playlistId);
                        cmd.Parameters.AddWithValue("@songID", songId);
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

        public static void RemoveFromPlaylist(string playlistName, Song song)
        {
            int playlistId = GetPlaylistId(playlistName);
            int songId = GetSongId(song.FilePath);

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(Queries.RemoveFromPlaylist, connection))
                    {
                        cmd.Parameters.AddWithValue("@playlistID", playlistId);
                        cmd.Parameters.AddWithValue("@songID", songId);
                        cmd.ExecuteNonQuery();
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
        }

        public static bool CheckLyricsExist(Song song)
        {
            int songId = GetSongId(song.FilePath);

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(Queries.CheckSongLyrics, connection))
                    {
                        cmd.Parameters.AddWithValue("@songId", songId);
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

        public static void AddSongLyrics(Song song, string lyrics)
        {
            int songId = GetSongId(song.FilePath);
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(Queries.AddLyrics, connection))
                    {
                        cmd.Parameters.AddWithValue("@songId", songId);
                        cmd.Parameters.AddWithValue("@lyrics", lyrics);
                        cmd.ExecuteNonQuery();
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
        }

        public static string GetSongLyrics(Song song)
        {
            int songId = GetSongId(song.FilePath);
            string lyrics = "";

            try
            {
                using(SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd  = new SQLiteCommand(Queries.GetLyrics, connection))
                    {
                        cmd.Parameters.AddWithValue("@songId", songId);
                        lyrics = cmd.ExecuteScalar().ToString();
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

            return lyrics;
        }
    }

}
