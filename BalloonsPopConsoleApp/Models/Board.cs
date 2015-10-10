// <copyright  file="Board.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Models
{
    using System;
    using System.Text;
    using BalloonsPop;
    using Factories;
    using Memory;
    using Miscellaneous;

    /// <summary>
    /// Board object that comprises balloon matrix.
    /// </summary>
    public class Board : IBoard
    {
        private const int MaxRowsCount = 15;
        private const int MinRowsCount = 5;
        private const int MaxColsCount = 15;
        private const int MinColsCount = 5;
        private readonly IBalloonFactory balloonFactory;
        private int rowsCount;
        private int colsCount;
        private IBalloon[,] board;

        /// <summary>
        /// Board object containing multiple Balloon objects. The Board serves as the interface through which Balloons are accessed
        /// </summary>
        /// <param name="rows">The max amount of rows the board will contain</param>
        /// <param name="cols">The max amount of columns the board will contain</param>
        public Board(int rows, int cols, IRandomGenerator randomGenerator)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.board = new IBalloon[this.Rows, this.Cols];
            this.RandomGenerator = randomGenerator;
            this.balloonFactory = new BalloonFactory();
            this.Fill();
        }

        /// <summary>
        /// Board's number of Rows - Must be between 5 and 15
        /// </summary>
        public int Rows
        {
            get
            {
                return this.rowsCount;
            }

            private set
            {
                if (value < MinRowsCount || value > MaxRowsCount)
                {
                    throw new ArgumentOutOfRangeException("board rows");
                }

                this.rowsCount = value;
            }
        }
        
        /// <summary>
        /// Board's number of Columns - Must be between 5 and 15
        /// </summary>
        public int Cols
        {
            get
            {
                return this.colsCount;
            }

            private set
            {
                if (value < MinColsCount || value > MaxColsCount)
                {
                    throw new ArgumentOutOfRangeException("board cols");
                }

                this.colsCount = value;
            }
        }

        /// <summary>
        /// Returns the amount of not-null values in the matrix
        /// </summary>
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

        private IRandomGenerator RandomGenerator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row">Ballon matrix row index</param>
        /// <param name="col">Ballon matrix column index</param>
        /// <returns>Balloon object</returns>
        public IBalloon this[int row, int col]
        {
            get
            {
                return this.board[row, col];
            }

            set
            {
                this.board[row, col] = value;
            }
        }

        /// <summary>
        /// Method resets the matrix and fills it anew
        /// </summary>
        public void Reset()
        {
            this.Fill();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row">Ballon matrix row index</param>
        /// <param name="col">Ballon matrix column index</param>
        /// <returns>True if the value of the matrix is not-null, False if no Balloon is present</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Memento object</returns>
        public IBoardMemento SaveMemento()
        {
            var clonedBoard = (IBalloon[,])this.board.Clone();

            return new Memento(clonedBoard);
        }

        /// <summary>
        /// Returns the Board to a previous stable state.
        /// </summary>
        /// <param name="memento">The caretaker's memento where a previous stable state is stored</param>
        public void RestoreMemento(IBoardMemento memento)
        {
            this.board = memento.Board;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>String representation of the Board object</returns>
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
            string separator = leftPadding + new string('-', this.Cols * 2);
            output.AppendLine(separator);

            for (int row = 0; row < this.Rows; row++)
            {
                output.Append(row + " | ");

                for (int col = 0; col < this.Cols; col++)
                {
                    if (this.board[row, col] == null)
                    {
                        output.Append(". ");
                        continue;
                    }

                    output.Append(this.board[row, col].Value + " ");
                }

                output.AppendLine("| ");
            }

            output.AppendLine(separator);

            return output.ToString();
        }

        private void Fill()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    var randomValue = this.RandomGenerator.GetInt(1, 5);
                    this[row, col] = this.balloonFactory.GetBalloon(randomValue);
                }
            }
        }
    }
}
