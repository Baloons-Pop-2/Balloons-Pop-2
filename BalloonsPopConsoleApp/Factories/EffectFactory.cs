namespace BalloonsPopConsoleApp.Factories
{
    using BalloonsPop;
    using BalloonsPop.Traversals;
    using Effects;

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
