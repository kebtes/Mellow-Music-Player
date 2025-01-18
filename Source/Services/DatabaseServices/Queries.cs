using System.Collections.Generic;

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
        public static string CheckSongInPlaylist = @"SELECT 1 FROM PlaylistSongs WHERE PlaylistID = @playlistID AND SongID = @songID LIMIT 1 COLLATE NOCASE;";
        public static string CheckSongLyrics = @"SELECT 1 FROM SongLyrics WHERE SongID == @songId";

        /*
         Data insertion and modification queries
         */
        public static string AddSong = @"
                            INSERT OR IGNORE INTO Songs (Title, Artist, Album, Genre, Duration, FilePath)
                            VALUES (@title, @artist, @album, @genre, @duration, @filePath);"
        ;
        public static string CreatePlaylist = @"INSERT INTO Playlists (PlaylistName, PlaylistColor, CreatedAt)
                            VALUES (@playlistName, @playlistColor, @currentTimeStamp)";

        public static string InsertIntoPlaylist = @"INSERT OR IGNORE INTO PlaylistSongs (PlaylistID, SongID)
                            VALUES (@playlistId, @songId);";

        public static string RemoveFromPlaylist = @"DELETE FROM PlaylistSongs
                            WHERE PlaylistID = @playlistID AND SongID = @songID;";

        public static string AddLyrics = @"INSERT OR IGNORE INTO SongLyrics(SongID, Lyrics)
                            VALUES(@songId, @lyrics);";

        
        //Table deletion queries
        public static string DeleteSongTable = "DELETE FROM Songs";
        public static string DeletePlaylistTable = "DELETE FROM Playlists";
        public static string DeletePlaylistSongsTable = "DELTEE FROM PlaylistSongs";

        /*
         Data retrieval queries
         */
        public static string GetSongs = "SELECT Title, Artist, Album, Genre, Duration, FilePath FROM Songs";

        public static string GetPlaylistID = @"SELECT PlaylistID FROM Playlists
                            WHERE PlaylistName = @playlistName COLLATE NOCASE;";

        public static string GetPlayListSongsById = @"SELECT Songs.SongID, Songs.Title, Songs.Artist, Songs.Album, Songs.Genre, Songs.Duration, Songs.FilePath, Songs.AlbumArtPath
                            FROM PlaylistSongs
                            INNER JOIN Songs 
                            ON PlaylistSongs.SongID = Songs.SongID
                            WHERE PlaylistSongs.PlaylistID = @playlistID;";

        public static string GetSongIdByFilePath = @"SELECT SongID FROM Songs WHERE FilePath = @filePath;";

        public static string GetPlaylists = @"SELECT PlaylistID, PlaylistName, PlaylistColor, CreatedAt FROM Playlists;";

        public static string GetLyrics = @"SELECT Lyrics
                            FROM SongLyrics
                            WHERE SongID == @songId;";

        public static string GetAlbumSongs = @"SELECT Title, Artist, Album, Genre, Duration, FilePath
                            FROM Songs
                            WHERE Album = @albumTitle COLLATE NOCASE;";


        public static string ClearPlaylistSongs = @"DELETE FROM PlaylistSongs WHERE PlaylistID = @playlistId";
        public static string DeletePlaylist = @"DELETE FROM Playlists WHERE PlaylistID = @playlistId";
    }
}
