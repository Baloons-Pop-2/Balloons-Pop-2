using System;
using System.Text;
using BalloonsPop;
using BalloonsPopConsoleApp.Factories;

namespace BalloonsPopConsoleApp
{
    public class Board : IBoard
    {
        private const int MaxRowsCount = 20;
        private const int MaxColsCount = 10;
        private int rowsCount;
        private int colsCount;
        private readonly IBalloon[,] board;
        private readonly IBalloonFactory balloonFactory;

        public Board(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.board = new IBalloon[this.Rows, this.Cols];
            this.balloonFactory = new BalloonFactory();
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
                if (value < 1 || value > MaxRowsCount)
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
                if (value < 1 || value > MaxColsCount)
                {
                    throw new ArgumentOutOfRangeException("board cols");
                }

                colsCount = value;
            }
        }

        public IBalloon this[int row, int col]
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

        public int UnpoppedBalloonsCount
        {
            get
            {
                int balloonsCount = 0;

                for (int row = 0; row < this.Rows; row++)
                {
                    for (int col = 0; col < this.Cols; col++)
                    {
                        if (this[row, col] != null)
                        {
                            balloonsCount++;
                        }
                    }
                }

                return balloonsCount;
            }
        }

        public void Reset()
        {
            this.Fill();
        }

        public bool IsValidPop(int row, int col)
        {
            bool rowIsInRange = 0 <= row && row < this.Rows;
            bool colIsInRange = 0 <= col && col < this.Cols;

            if (rowIsInRange && colIsInRange)
            {
                bool balloonExists = this[row, col] != Balloon.Default;
                return balloonExists;
            }

            return false;
        }

        private void Fill()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    var randomValue = int.Parse(RandomGenerator.GetRandomInt());
                    this[row, col] = this.balloonFactory.GetBalloon(randomValue);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string leftPadding = new string(' ', 4);

            output.Append(leftPadding);
            for (int col = 0; col < this.Cols; col++)
            {
                output.Append(col + " ");
            }

            output.AppendLine();
            string separator = leftPadding + new string('-', 21);
            output.AppendLine(separator);

            for (int row = 0; row < this.Rows; row++)
            {
                output.Append(row + " | ");

                for (int col = 0; col < this.Cols; col++)
                {
                    if (board[row, col] == null)
                    {
                        output.Append(". ");
                        continue;
                    }
                    output.Append(board[row, col].Value + " ");
                }
                output.AppendLine("| ");
            }

            output.AppendLine(separator);
            
            return output.ToString();
        }
    }
}
