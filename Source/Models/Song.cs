using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mellow_Music_Player.Source.Models
{
    internal class Song
    {
        public string Title { get; set; }
        public string[] Artists { get; set; }
        public string Album { get; set; }
        public string[] Genres { get; set; }
        public TimeSpan Duration { get; set; }
        public string FilePath { get; set; }
        public Image AlbumArt { get; set; }
    }
}
