using System;
using System.Collections.Generic;
using BalloonsPop;
using BalloonsPop.Traversals;

namespace BalloonsPopConsoleApp.Factories
{
    public class BalloonFactory : IBalloonFactory
    {
        private readonly Dictionary<int, IBalloon> balloonsList;
        private readonly IEffectFactory effectFactory;

        public BalloonFactory()
        {
            this.balloonsList = new Dictionary<int, IBalloon>();
            this.effectFactory = new EffectFactory();
        }

        public IBalloon GetBalloon(int value)
        {
            if (this.balloonsList.ContainsKey(value))
            {
                return this.balloonsList[value];
            }
            else
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

                var balloon = new Balloon(value, effect);

                this.balloonsList.Add(value, balloon);

                return balloon;
            }
        }
    }
}
