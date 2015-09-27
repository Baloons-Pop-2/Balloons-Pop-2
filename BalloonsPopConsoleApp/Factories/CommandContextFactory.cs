using BalloonsPop;

namespace BalloonsPopConsoleApp.Factories
{
    public class CommandContextFactory : ICommandContextFactory
    {
        public ICommandContext GetNullCommandContext()
        {
            return new NullCommandContext();
        }

        public ICommandContext GetPopCommandContext(IBoard board, int row, int col)
        {
            return new CommandContext(board, row, col);
        }

        public ICommandContext GetMementoCommandContext(IBoard board, IBoardMemory memory)
        {
            return new CommandContext(board, memory);
        }

        public ICommandContext GetBoardCommandContext(IBoard board)
        {
            return new CommandContext(board);
        }
    }
}
