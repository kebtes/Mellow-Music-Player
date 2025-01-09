namespace Mellow_Music_Player.Source
{
    public class Settings
    {
        private static string songsDirectory = "C:\\Users\\CompUser\\Desktop\\Mellow Music Player\\Sample";

        private float volume = 1.0f;

        public float Volume
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

        public Settings() { }
    }
}
