namespace BalloonsPop
{
    public interface ICommandContext
    {
        IBoard Board { get; }

        int ActiveCol { get; }

        int ActiveRow { get; }

        IBoardMemory Memory { get; }
    }
}
