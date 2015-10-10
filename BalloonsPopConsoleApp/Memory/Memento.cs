// <copyright  file="Memento.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Memory
{
    using BalloonsPop;

    /// <summary>
    /// The class is responsible for storing the board object's stable state.
    /// </summary>
    public class Memento : IBoardMemento
    {
        /// <summary>
        /// Instance of the board matrix.
        /// </summary>
        private IBalloon[,] board;

        /// <summary>
        /// Initializes a new instance of the <see cref="Memento"/> class which stores the board's state.
        /// </summary>
        /// <param name="board">the object that is being stored for restoration at a later point.</param>
        public Memento(IBalloon[,] board)
        {
            this.Board = board;
            this.Rows = board.GetLength(0);
            this.Cols = board.GetLength(1);
        }

        /// <summary>
        /// Gets or sets the Memento object's size.
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// Gets or sets the Memento object's size.
        /// </summary>
        public int Cols { get; set; }

        /// <summary>
        /// Gets board's stored state.
        /// </summary>
        public IBalloon[,] Board
        {
            get
            {
                return (IBalloon[,])this.board.Clone();
            }

            private set
            {
                this.board = value;
            }
        }
    }
}
