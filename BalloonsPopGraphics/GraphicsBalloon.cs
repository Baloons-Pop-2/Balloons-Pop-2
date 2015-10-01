using BalloonsPop;
using BalloonsPop.Traversals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BalloonsPopGraphics
{
    public class GraphicsBalloon : Image, IGraphicsBalloon
    {
        private ITraversalEffect effect;

        public GraphicsBalloon(int value, ITraversalEffect traversalEffect)
        {
            this.Value = value;
            this.TraversalEffect = traversalEffect;
        }

        public int Value { get; set; }

        public ITraversalEffect TraversalEffect
        {
            get
            {
                return this.effect;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("effect");
                }

                this.effect = value;
            }
        }

        private Uri ImageSource
        {
            get { return new Uri(@"\Images\" + this.Value + ".png", UriKind.Relative); }
        }

        public Image Image
        {
            get 
            {
                var image = new Image();
                image.Source = new BitmapImage(this.ImageSource);
                return image;
            }
        }

        public int Row
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Col
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
