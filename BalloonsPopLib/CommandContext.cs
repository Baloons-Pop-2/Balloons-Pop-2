namespace BalloonsPop
{
    public class CommandContext
    {
        public CommandContext()
        {
        }

        public CommandContext(IBoard board, int activeRow, int activeCol)
        {
            this.Board = board;
            this.ActiveRow = activeRow;
            this.ActiveCol = activeCol;
        }

        public IBoard Board { get; private set; }

        public int ActiveCol { get; private set; }

        public int ActiveRow { get; private set; }
    }
}
