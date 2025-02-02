using System.Text.Json;
using System;
using System.IO;
using System.Text.Json;

namespace Mellow_Music_Player.Source
{
    public class Settings
    {
        private static string songsDirectory = "C:\\Users\\CompUser\\Music";
        private static float volume = 1.0f;
        
        private static string filePath = "C:\\Users\\CompUser\\Mellow-Music-Player\\Source\\settings.json";

        private Settings() {
            //Load();
        }

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

        private class SettingsSerializable
        {
            public string SongsDirectory { get; set; }
            public string LastOpenedPlaylist { get; set; }
            public float Volume { get; set; }

        }

        public static void Save()
        {
            var settingsObject = new SettingsSerializable
            {
                SongsDirectory = songsDirectory,
                Volume = volume,
            };

            string json = JsonSerializer.Serialize(settingsObject, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static void Load()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    var settingsObject = JsonSerializer.Deserialize<SettingsSerializable>(json);

                    if (settingsObject != null)
                    {
                        songsDirectory = settingsObject.SongsDirectory;
                        volume = settingsObject.Volume;
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Settings file not found. Loading default settings." + ex);
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Settings file is corrupted. Resetting to default settings." + ex);
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"I/O error: {ex.Message}. Please try again.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }
    }
}
