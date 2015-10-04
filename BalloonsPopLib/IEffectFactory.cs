namespace BalloonsPop
{
    using Traversals;

    public interface IEffectFactory
    {
        ITraversalEffect GetDefaultEffect();

        ITraversalEffect GetAreaPopEffect();
    }
}
