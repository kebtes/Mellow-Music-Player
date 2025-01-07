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
        public static string PlayButtonSmallIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "PlayButtonSmall.png");
        public static string PlayButtonSmallSelectedIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "PlayButtonSmall-Selected.png");
        public static string PlayButtonIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "PlayButton.png");
        public static string PlayButtonSelectedIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "PlayButton-Selected.png");
        public static string PauseButtonIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "PauseButton.png");
        public static string PauseButtonSelectedIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "PauseButton-Selected.png");
        
        public static string ProjectFont = "Geist";


    }
}
