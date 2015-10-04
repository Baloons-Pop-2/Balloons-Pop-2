namespace BalloonsPop
{
    using Traversals;

    public interface IBalloon
    {
        int Value { get; }

        ITraversalEffect TraversalEffect { get; }
    }
}
