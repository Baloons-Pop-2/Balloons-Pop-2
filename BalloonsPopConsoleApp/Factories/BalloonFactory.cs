namespace BalloonsPopConsoleApp.Factories
{
    using System;
    using System.Collections.Generic;
    using BalloonsPop;
    using BalloonsPop.Traversals;
    using Models;

    /// <summary>
    /// BalloonFactory pattern that take care of create instances of the Balloon class.
    /// </summary>
    public class BalloonFactory : IBalloonFactory
    {
        private readonly Dictionary<int, IBalloon> balloonsList;
        private readonly IEffectFactory effectFactory;

        /// <summary>
        /// BalloonFactory object constructor.
        /// </summary>
        public BalloonFactory()
        {
            this.balloonsList = new Dictionary<int, IBalloon>();
            this.effectFactory = new EffectFactory();
        }

        /// <summary>
        /// Method that get the Balloon with a concrete value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Instance of one certain balloon</returns>
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
