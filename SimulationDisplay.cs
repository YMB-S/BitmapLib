using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using FastBitmapLib;

namespace BitmapLib
{
    internal class SimulationDisplay
    {
        public static readonly int DISPLAY_WIDTH = 100;
        public static readonly int DISPLAY_HEIGHT = 100;

        Bitmap bitmap;

        public SimulationDisplay()
        {
            bitmap = new Bitmap(DISPLAY_WIDTH, DISPLAY_HEIGHT);
        }

        public BitmapImage GetImage()
        {
            DrawTo(bitmap);
            return ToBitmapImage(bitmap);
        }

        public void Update()
        {
        }

        public void DrawTo(Bitmap target)
        {
            using (var bitmap = target.FastLock())
            {
                bitmap.Clear(Color.White);
            }
        }

        private BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
    }
}
