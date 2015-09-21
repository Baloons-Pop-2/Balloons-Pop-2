using BalloonsPop.Traversals;

namespace BalloonsPop
{
    public interface IEffectFactory
    {
        ITraversalEffect GetDefaultEffect();
        ITraversalEffect GetAreaPopEffect();
    }
}
