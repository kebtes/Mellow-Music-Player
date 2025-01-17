using Mellow_Music_Player.Source.Services.Database_Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mellow_Music_Player.Source.Services
{
    public static class LyricsService
    {
        private static async Task<string> Fetch(string songTitle, string artist)
        {
            string baseUrl = "https://musixmatch-lyrics-songs.p.rapidapi.com/songs/lyrics";
            string uriString = $"{baseUrl}?t={Uri.EscapeDataString(songTitle)}&a={Uri.EscapeDataString(artist)}&d=0&type=text";

            string RapidApiKey = "55f5b01849msh8882a0a3568208bp12c558jsn91672897a5d0";
            string RapidApiHost = "musixmatch-lyrics-songs.p.rapidapi.com";

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uriString),
                Headers =
            {
                { "x-rapidapi-key", RapidApiKey },
                { "x-rapidapi-host", RapidApiHost},
            },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
                // Console.WriteLine(body);
            }
        }

        private static List<string> Parse(string lyrics)
        {
            var output = new List<string>();
            string pattern = @"\[(\d{2}:\d{2}\.\d{2})\](.*)";

            //string[] lyricsSplitted = lyrics.Split("\n");
            string[] lyricsSplitted = lyrics.Split('\n');

            foreach (string line in lyricsSplitted)
            {
                Match match = Regex.Match(line, pattern);

                if (match.Success)
                {
                    // string timestamp = match.Groups[1].Value;
                    string text = match.Groups[2].Value;
                    output.Add(text);
                }
            }
            return output;
        }

        public static async Task<bool> GetLyrics(Song song)
        {
            //Fetches the desired lyrics and saves it in the Database

            try
            {
                string title = song.Title;
                string artists = string.Join(",", song.Artists);

                var response = await Fetch(title, artists);
                var lyrics = Parse(response);
                DatabaseService.AddSongLyrics(song, string.Join(Environment.NewLine, lyrics));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetLyrics", ex);
            }

        }
    }
}

