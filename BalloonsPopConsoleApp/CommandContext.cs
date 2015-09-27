using BalloonsPop;

namespace BalloonsPopConsoleApp
{
    public class CommandContext : ICommandContext
    {
        public CommandContext(IBoard board, int activeRow, int activeCol)
            : this(board)
        {
            this.ActiveRow = activeRow;
            this.ActiveCol = activeCol;
        }

        public CommandContext(IBoard board, IBoardMemory memory) 
            : this(board)
        {
            this.Memory = memory;
        }

        public CommandContext(IBoard board)
        {
            this.Board = board;
        }

        public IBoard Board { get; private set; }

        public int ActiveCol { get; private set; }

        public int ActiveRow { get; private set; }

        public IBoardMemory Memory { get; private set; }
    }
}
