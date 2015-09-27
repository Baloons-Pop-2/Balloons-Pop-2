using BalloonsPop;

namespace BalloonsPopConsoleApp
{
    public class Constraints : IConstraints
    {
        public Constraints(int rows, int cols)
        {
            this.BoardRows = rows;
            this.BoardColumns = cols;
        }

        public int BoardRows { get; private set; }

        public int BoardColumns { get; private set; }
    }
}
