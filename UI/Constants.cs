﻿using System.ComponentModel;
using System.IO;
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
        public const string HighlightColor = "#E67F0D";

        public static string ProjectFont = "Geist";

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
        public static string NextButtonIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "NextButton.png");
        public static string NextButtonSelectedIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "NextButton-Selected.png");
        public static string PreviousButtonIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "PrevButton.png");
        public static string PreviousButtonSelectedIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "PrevButton-Selected.png");
        public static string SearchBar = Path.Combine(Application.StartupPath, "Assets", "Icons", "SearchBar.png");
        public static string SearchBarSelected = Path.Combine(Application.StartupPath, "Assets", "Icons", "SearchBar-Selected.png");
        public static string DeleteIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "Delete.png");
        public static string DeleteSelectedIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "Delete-Selected.png");
        public static string AddIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "Add.png");
        public static string AddIconSelected = Path.Combine(Application.StartupPath, "Assets", "Icons", "Add-Selected.png");
        public static string HeartIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "Heart.png");
        public static string HeartIconSelected = Path.Combine(Application.StartupPath, "Assets", "Icons", "Heart-Selected.png");
        public static string DownloadIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "Download.png");
        public static string DownloadSelectedIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "Download-Selected.png");
        public static string ErrorIcon = Path.Combine(Application.StartupPath, "Assets", "Icons", "Error.png");

        //Component locations
        public static string PlaylistCardRed = Path.Combine(Application.StartupPath, "Assets", "Components", "PlaylistRectangle_Red.png");
        public static string PlaylistCardGreen = Path.Combine(Application.StartupPath, "Assets", "Components", "PlaylistRectangle_Green.png");
        public static string PlaylistCardPurple = Path.Combine(Application.StartupPath, "Assets", "Components", "PlaylistRectangle_Purple.png");
    }
}
