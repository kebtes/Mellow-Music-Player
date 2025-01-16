namespace Mellow_Music_Player.Source
{
    public class Settings
    {
        private static string songsDirectory = "C:\\Users\\CompUser\\Mellow-Music-Player\\Sample";
        private static float volume = 1.0f;
        private static string lastOpenedPlaylist = null;

        public Settings() { }
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
        }

        public static string LastOpenedPlaylist
        {
            get => lastOpenedPlaylist;
            set { lastOpenedPlaylist = value; }
        }
    }
}
