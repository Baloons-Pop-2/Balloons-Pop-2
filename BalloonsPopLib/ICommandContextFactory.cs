namespace BalloonsPop
{
    public interface ICommandContextFactory
    {
        ICommandContext GetNullCommandContext();
        ICommandContext GetPopCommandContext(IBoard board, int row, int col);
        ICommandContext GetMementoCommandContext(IBoard board, IBoardMemory memory);
        ICommandContext GetBoardCommandContext(IBoard board);
    }
}
