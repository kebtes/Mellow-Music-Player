using System;
using System.Collections.Generic;
using Mellow_Music_Player.Source.Services.Database_Services;

namespace Mellow_Music_Player.Source.Services.DatabaseServices
{
    public enum Fields
    {
        /*
         This enumeration is primarily used to track the specific field in which a 
        keyword match occurred during a search operation. This information is then 
        utilized to highlight the corresponding labels when displaying search results.
         */

        Title,
        Artist,
        Album
    }

    public static class SearchService
    {
        public static List<Tuple<Song, Fields>> Search(string keyword)
        {
            List<Tuple<Song, Fields>> output = new List<Tuple<Song, Fields>>();

            List<Song> songs = DatabaseService.GetSongs();

            foreach (Song song in songs)
            {
                keyword = keyword.ToLower();

                string title = song.Title.ToLower();
                string artists = string.Join(" ", song.Artists).ToLower();
                string album = song.Album.ToLower();

                if (title.StartsWith(keyword))
                {
                    output.Add(new Tuple<Song, Fields>(song, Fields.Title)); 
                }
                else if (artists.StartsWith(keyword))
                {
                    output.Add(new Tuple<Song, Fields>(song, Fields.Artist)); 
                }
                else if (album.StartsWith(keyword))
                {
                    output.Add(new Tuple<Song, Fields>(song, Fields.Album)); 
                }
            }

            return output;
        }
    }
}
