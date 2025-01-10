using System;
using System.IO;

namespace Mellow_Music_Player.Source.Services
{
    public static class Constant
    {
        /*
         Database connection string and sqlite .db file path
         */
        public static string DBFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "mellow.db");
        public static string DBConnectionString = $"Data Source={DBFilePath};Version=3;";
    }
}
