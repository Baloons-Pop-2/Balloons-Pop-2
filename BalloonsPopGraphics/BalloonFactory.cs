using BalloonsPop;
using BalloonsPop.Traversals;
using BalloonsPopConsoleApp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopGraphics
{
    public class GraphicsBalloonFactory
    {
        private readonly Dictionary<int, GraphicsBalloon> balloonsList;
        private readonly IEffectFactory effectFactory;

        public GraphicsBalloonFactory()
        {
            this.balloonsList = new Dictionary<int, GraphicsBalloon>();
            this.effectFactory = new EffectFactory();
        }

        public GraphicsBalloon GetBalloon(int value)
        {
                ITraversalEffect effect;

                switch (value)
                {
                    case 1:
                        effect = this.effectFactory.GetDefaultEffect();
                        break;
                    case 2:
                        effect = this.effectFactory.GetDefaultEffect();
                        break;
                    case 3:
                        effect = this.effectFactory.GetDefaultEffect();
                        break;
                    case 4:
                        effect = this.effectFactory.GetDefaultEffect();
                        break;
                    case 5:
                        effect = this.effectFactory.GetAreaPopEffect();
                        break;
                    default:
                        throw new ArgumentException("Invalid balloon value.");
                }

                var balloon = new GraphicsBalloon(value, effect);
                return balloon;
        }
    }
}
