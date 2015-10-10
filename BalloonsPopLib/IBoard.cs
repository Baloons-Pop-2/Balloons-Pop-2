// <copyright file="IBoard.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop
{
    /// <summary>
    /// The interface of the board that holds the balloons.
    /// </summary>
    public interface IBoard : IMemorizeable<IBoardMemento>
    {
        /// <summary>
        /// Gets the number of rows on the board.
        /// </summary>
        int Rows { get; }

        /// <summary>
        /// Gets the number of columns on the board.
        /// </summary>
        int Cols { get; }

        /// <summary>
        /// Gets the number of not popped balloons on the board.
        /// </summary>
        int UnpoppedBalloonsCount { get; }
        
        /// <summary>
        /// The board indexer.
        /// </summary>
        /// <param name="row">Gets the concrete row (0-based).</param>
        /// <param name="col">Gets the concrete column (0-based).</param>
        /// <returns>An object which implements IBalloon.</returns>
        IBalloon this[int row, int col] { get; set; }

        /// <summary>
        /// Refills The entire board with random balloons.
        /// </summary>
        void Reset();

        /// <summary>
        /// Checks if the balloon on a certain position is popped.
        /// </summary>
        /// <param name="row">Gets the concrete row (0-based).</param>
        /// <param name="col">Gets the concrete column (0-based).</param>
        /// <returns>True if the balloon is popped, false - otherwise.</returns>
        bool IsValidPop(int row, int col);
    }
}
