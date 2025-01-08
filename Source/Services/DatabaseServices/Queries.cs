using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib.Jpeg;

namespace Mellow_Music_Player.Source.Services.Database_Services
{
    internal class Queries
    {
        /*
         Table creation queries 
         */
        public static string SongTables = @"
                    CREATE TABLE IF NOT EXISTS Songs (
                        SongID INTEGER PRIMARY KEY,
                        Title TEXT NOT NULL,
                        Artist TEXT,
                        Album TEXT,
                        Genre TEXT,
                        Duration INTEGER,
                        FilePath TEXT NOT NULL,
                        AlbumArtPath TEXT
                    );";


        public static string PlaylistTable = @"CREATE TABLE IF NOT EXISTS Playlists (
                        PlaylistID INTEGER PRIMARY KEY,
                        PlaylistName TEXT NOT NULL,
                        CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                    );";

        public static string PlaylistSongsTable = @"CREATE TABLE IF NOT EXISTS PlaylistSongs (
                        PlaylistID INTEGER,
                        SongID INTEGER,
                        FOREIGN KEY (PlaylistID) REFERENCES Playlists(PlaylistID),
                        FOREIGN KEY (SongID) REFERENCES Songs(SongID)
                    );";


        /*
         Query to check if certain tables exist
         */
        public static string CheckSongTable = @"
                        SELECT name 
                        FROM sqlite_master 
                        WHERE type='table' AND name='Songs';
                    ";

        /*
         Queries to check if certain data exist
         */
        public static string CheckSongExists = @"SELECT EXISTS(SELECT 1 FROM Songs WHERE FilePath = @filePath)";

        /*
         Data insertion and modification queries
         */
        public static string AddSong = @"
                            INSERT INTO Songs (Title, Artist, Album, Genre, Duration, FilePath)
                            VALUES (@title, @artist, @album, @genre, @duration, @filePath);";

        //Table deletion queries
        public static string DeleteSongTable = "DELETE FROM Songs";
        public static string DeletePlaylistTable = "DELETE FROM Playlists";
        public static string DeletePlaylistSongsTable = "DELTEE FROM PlaylistSongs";

        /*
         Data retrieval queries
         */
        public static string GetSongs = "SELECT Title, Artist, Album, Genre, Duration, FilePath FROM Songs";


    }
}
