namespace Mellow_Music_Player.Source
{
    public class Settings
    {
        private static string songsDirectory;
        private static float volume = 1.0f;
        private static string lastOpenedPlaylist = null;
        private static string filePath = "settings.json";

        private Settings() { }

        public static float Volume
        {
            get => volume;
            set
            {
                if (value >= 0.0f && value <= 1.0f)
                {
                    volume = value;
                }
            }
        }

        public static string SongsDirectory
        {
            get => songsDirectory;
            set => songsDirectory = value;
        }

        public static string LastOpenedPlaylist
        {
            get => lastOpenedPlaylist;
            set => lastOpenedPlaylist = value;
        }
    }
}
