using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopGraphics
{
    public class GraphicsBalloonFactory
    {
        private ImageSourceFactory imageSourceFactory;

        public GraphicsBalloonFactory(ImageSourceFactory imageSourceFactory)
        {
            this.imageSourceFactory = imageSourceFactory;
        }

        public GraphicsBalloon GetBalloon(int value)
        {
            switch (value)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    return new GraphicsBalloon(value, new GraphicsBFSTraversal(),
                        this.imageSourceFactory.GetSource(value), this.imageSourceFactory);
                case 5:
                    return new GraphicsBalloon(value, new GraphicsAreaTraversal(),
                        this.imageSourceFactory.GetSource(value), this.imageSourceFactory);
                default:
                    throw new ArgumentException("Invalid value");
            }
        }
    }
}
