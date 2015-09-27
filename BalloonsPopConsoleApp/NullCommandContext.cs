using BalloonsPop;

namespace BalloonsPopConsoleApp
{
    public class NullCommandContext : ICommandContext
    {
        public NullCommandContext(IBoard board)
        {
            this.Board = board;
        }

        public IBoard Board { get; private set; }

        public int ActiveCol { get; private set; }

        public int ActiveRow { get; private set; }

        public IBoardMemory Memory { get; private set; }
    }
}
