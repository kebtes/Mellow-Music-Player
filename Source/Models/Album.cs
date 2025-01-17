using System.Collections.Generic;
using System.Drawing;

namespace Mellow_Music_Player.Source.Models
{
    public class Album
    {
        public string AlbumName { get; set; }
        public string Artists { get; set; }
        public Image AlbumArt { get; set; }
        public List<Song> Songs { get; set; }
    }
}
