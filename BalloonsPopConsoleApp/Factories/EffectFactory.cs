using BalloonsPop;
using BalloonsPop.Traversals;
using BalloonsPopConsoleApp.Effects;

namespace BalloonsPopConsoleApp.Factories
{
    public class EffectFactory : IEffectFactory
    {
        public ITraversalEffect GetDefaultEffect()
        {
            return new BfsEffect();
        }

        public ITraversalEffect GetAreaPopEffect()
        {
            return new AreaPopEffect();
        }
    }
}
