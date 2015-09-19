using BalloonsPop;

namespace BalloonsPopConsoleApp
{
    public class Constraints : IConstraints
    {
        public Constraints(int minValue, int maxValue, int rows, int cols)
        {
            this.BalloonMinValue = minValue;
            this.BalloonMaxValue = maxValue;
            this.BoardRows = rows;
            this.BoardColumns = cols;
        }


        public int BalloonMinValue { get; private set; }

        public int BalloonMaxValue { get; private set; }

        public int BoardRows { get; private set; }

        public int BoardColumns { get; private set; }
    }
}
