using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BalloonsPopGraphics
{
    public class ImageSourceFactory
    {
        private readonly Dictionary<int, BitmapImage> sources;

        public ImageSourceFactory()
        {
            this.sources = new Dictionary<int, BitmapImage>();
        }
        public BitmapImage GetSource(int value)
        {
            if (this.sources.ContainsKey(value))
            {
                return this.sources[value];
            }
            else
            {
                BitmapImage source;

                switch (value)
                {
                    case 0:
                    case 1: 
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        source = new BitmapImage(new Uri(@"\Images\" + value + ".png", UriKind.Relative));
                        break;
                    default:
                        throw new ArgumentException("Invalid value");
                }

                this.sources.Add(value, source);

                return source;
            }
        }
    }
}
