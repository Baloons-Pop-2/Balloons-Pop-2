using BalloonsPop.Traversals;

namespace BalloonsPop
{
    public interface IBalloon
    {
        int Value { get; }
        ITraversalEffect TraversalEffect { get; }
    }
}
