// <copyright file="IHighscore.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop
{
    /// <summary>
    /// The interface of the game high scores.
    /// </summary>
    public interface IHighscore
    {
        /// <summary>
        /// Gets the current moves count. Increments every time the player makes a move.
        /// </summary>
        int CurrentMoves { get; }

        /// <summary>
        /// Gets the current score.
        /// </summary>
        int CurrentScore { get; }

        /// <summary>
        /// Gets the player's username.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// Sets the username of the player.
        /// </summary>
        /// <param name="name">The username of the player.</param>
        /// <returns>Returns itself so a fluent interface can be achieved.</returns>
        IHighscore SetUsername(string name);

        /// <summary>
        /// Sets the moves of the player.
        /// </summary>
        /// <param name="score">The player's moves.</param>
        /// <returns>Returns itself so a fluent interface can be achieved.</returns>
        IHighscore SetMoves(int score);

        /// <summary>
        /// Sets the score of the player based on the size of the board.
        /// </summary>
        /// <param name="boardSize">The size of the board.</param>
        void SetScore(int boardSize);
    }
}
