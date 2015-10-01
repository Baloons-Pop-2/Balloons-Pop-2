using BalloonsPop;
using BalloonsPopConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopGraphics
{
    class GraphicsBoard
    {
        private const int MaxRowsCount = 15;
        private const int MinRowsCount = 5;
        private const int MaxColsCount = 15;
        private const int MinColsCount = 5;
        private int rowsCount;
        private int colsCount;
        private GraphicsBalloon[,] board;
        private readonly GraphicsBalloonFactory balloonFactory;

        public GraphicsBoard(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.board = new GraphicsBalloon[this.Rows, this.Cols];
            this.balloonFactory = new GraphicsBalloonFactory();
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
                if (value < MinRowsCount || value > MaxRowsCount)
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
                if (value < MinColsCount || value > MaxColsCount)
                {
                    throw new ArgumentOutOfRangeException("board cols");
                }

                colsCount = value;
            }
        }

        public GraphicsBalloon this[int row, int col]
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
                return true;
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

        public IBoardMemento SaveMemento()
        {
            var clonedBoard = (IBalloon[,])this.board.Clone();

            return new Memento(clonedBoard);
        }

        public void RestoreMemento(IBoardMemento memento)
        {
            //this.board = memento.Board;
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
            string separator = leftPadding + new string('-', this.Cols*2);
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
