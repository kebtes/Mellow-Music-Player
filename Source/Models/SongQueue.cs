using Mellow_Music_Player.Source.Services;
using Mellow_Music_Player.Source.Services.Database_Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mellow_Music_Player.Source.Models
{
    public class SongQueue
    {
        private List<Song> songs;
        private static int currentIdx = -1;

        public SongQueue()
        {
            songs = DatabaseService.GetSongs();
        }
        public Song GetCurrentSong()
        {
            if (currentIdx == -1 && songs.Any())
            {
                currentIdx = 0;
            }

            return currentIdx >= 0 ? songs[currentIdx] : null;
        }

        public Song GetNextSong()
        {
            if (!songs.Any()) return null;
            currentIdx = (currentIdx + 1) % songs.Count;
            return songs[currentIdx];
        }

        public Song GetPrevSong()
        {
            if (!songs.Any()) return null;
            currentIdx = Math.Max(currentIdx - 1, 0);
            return songs[currentIdx];
        }

        public List<Song> GetAllSongs()
        {
            return songs;
        }
        
    }
}
