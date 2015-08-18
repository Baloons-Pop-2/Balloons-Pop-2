using System;

namespace BalloonsPops
{
    public class Board
    {
        private const int MaxRowsCount = 20;
        private const int MaxColsCount = 10;
        private int rowsCount;
        private int colsCount;
        private Balloon[,] board;

        public Board(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.board = new Balloon[this.Rows, this.Cols];
            this.Fill();
        }

        public int Rows
        {
            get
            {
                return rowsCount;
            }

            set
            {
                if (value < 1 || value > Board.MaxRowsCount)
                {
                    throw new ArgumentOutOfRangeException("board rows");
                }

                rowsCount = value;
            }
        }


        public int Cols
        {
            get
            {
                return colsCount;
            }

            set
            {
                if (value < 1 || value > Board.MaxColsCount)
                {
                    throw new ArgumentOutOfRangeException("board cols");
                }

                colsCount = value;
            }
        }

        public Balloon this[int row, int col]
        {
            get
            {
                return board[row, col];
            }

            set
            {
                board[row, col] = value;
            }
        }

        private void Fill()
        {
            int randomValue;

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    randomValue = int.Parse(RandomGenerator.GetRandomInt());
                    this[row, col] = new Balloon(randomValue);

                }
            }
        }
    }
}
