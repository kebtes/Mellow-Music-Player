using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mellow_Music_Player.Source
{
    public static class ScaleImage
    {
        public static Image Scale(Image originalImage, int width = 45, int height = 45)
        {
            Bitmap scaledBitmap = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(scaledBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, width, height);
            }

            return scaledBitmap;
        }
    }
}
