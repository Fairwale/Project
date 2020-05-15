using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Shop
{
    public class ImagePool
    {
        private Dictionary<string, Image> images = new Dictionary<string, Image>();

        public ImagePool()
        {

        }

        public Image GetImage(string name)
        {
            return images[name];
        }

        public void AddImage(string name)
        {
            Image im = new Image();
            im.MaxWidth = 256;
            im.MaxHeight = 256;
            //im.Width = 256;
            //im.Height = 256;
            //im.Stretch = System.Windows.Media.Stretch.Fill;

            im.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\images\\" + name + ".jpg", UriKind.Absolute));
            images.Add(name, im);
        }

        public Dictionary<string, Image> GetImages()
        {
            return images;
        }


    }
}
