namespace BalloonsPop
{
    public interface ICommandContextFactory
    {
        ICommandContext GetNullCommandContext(IBoard board);
        ICommandContext GetPopCommandContext(IBoard board, int row, int col);
        ICommandContext GetMementoCommandContext(IBoard board, IBoardMemory memory);
    }
}
