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
        ImageSourceFactory imageSourceProvider;
        public GraphicsBalloon(int value, GraphicsTraversal traversal, BitmapImage imageSource, ImageSourceFactory imageSourceProvider)
            :base()
        {
            this.imageSourceProvider = imageSourceProvider;
            this.IsPopped = false;
            this.Value = value;
            this.TraversalEffect = traversal;
            this.ImageSource = imageSource;
        }

        public int Value { get; private set; }

        public GraphicsTraversal TraversalEffect { get; private set; }

        public BitmapImage ImageSource { get; private set; }

        public bool IsPopped { get; set; }

        public void Pop()
        {
            this.IsPopped = true;
            this.Source = this.imageSourceProvider.GetSource(0);
        }

        public void Unpop()
        {
            this.IsPopped = false;
            this.Source = this.imageSourceProvider.GetSource(this.Value);
        }
    }
}
