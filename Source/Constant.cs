using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
