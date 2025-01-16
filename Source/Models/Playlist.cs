using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mellow_Music_Player.Source.Models
{
    public class Playlist
    {
        private int playlistId;
        private string playlistName;
        private DateTime createdAt;
        private string playlistColor;

        public int PlaylistId
        {
            get => playlistId;
            set => playlistId = value;
        }

        public string PlaylistName
        {
            get => playlistName;
            set => playlistName = value;
        }

        public string PlaylistColor
        {
            get => playlistColor; 
            set => playlistColor = value;
        }

        public DateTime CreatedAt
        {
            get => createdAt;
            set => createdAt = value;
        }
    }
}
