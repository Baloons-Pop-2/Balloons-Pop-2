using System.Collections.Generic;

namespace BalloonsPop
{
    public class ConcreteImplementations
    {
        public IBalloon Balloon { get; private set; }
        public IBalloon NullBalloon { get; private set; }
        public IBoard Board { get; private set; }
        public IBalloonFactory BalloonFactory { get; private set; }
        public IEffectFactory EffectFactory { get; private set; }
        public IConstraints Constraints { get; private set; }

    }
}
