using System.Collections.Generic;
using BalloonsPop;
using BalloonsPopConsoleApp.Effects;

namespace BalloonsPopConsoleApp
{
    public class BalloonFactory : IBalloonFactory
    {
        private IConstraints constraints;
        private readonly Dictionary<int, IBalloon> balloonsList = new Dictionary<int, IBalloon>();

        public BalloonFactory(IConstraints constraints)
        {
            this.constraints = constraints;
        }

        public IBalloon GetBalloon(int value)
        {
            if (this.balloonsList.ContainsKey(value))
            {
                return this.balloonsList[value];
            }
            else
            {
                var balloon = new Balloon(value, new BfsEffect());

                this.balloonsList.Add(value, balloon);

                return balloon;
            }
        }
    }
}
