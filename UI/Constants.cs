using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mellow_Music_Player.UI
{
    internal static class Constants
    {
        // Color 
        public const string OrangeColor = "#FF5F1B";
        public const string DarkBlue = "#0B0E15";
        public const string DarkBlue2 = "#181B22";
        public const string HoverBlue = "#1F1814";
        public const string HoverGrey = "#383C46";


        public const int HoverPenWidth = 5;

        // Icon locations
        public static string PlaylistIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "Playlist.png");
        public static string PlaylistSelectedIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "Playlist-Selected.png");
        public static string FeedIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "Feed.png");
        public static string FeedSelectedIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "Feed-Selected.png");
        

    }
}
