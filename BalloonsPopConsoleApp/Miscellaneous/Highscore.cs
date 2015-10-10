// <copyright  file="Highscore.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Miscellaneous
{
    using BalloonsPop;

    /// <summary>
    /// Score object containing information about the player's current moves. Username is set on demand.
    /// </summary>
    public class Highscore : IHighscore
    {
        public const int TheAnswerToEverything = 42;
        private static IHighscore instance;
        
        private Highscore()
        {
        }

        /// <summary>
        /// Gets or sets the player's current moves. Increments on every player's move.
        /// </summary>
        public int CurrentMoves { get; set; }


        /// <summary>
        /// Gets the player's current score.
        /// </summary>
        public int CurrentScore { get; private set; }

        /// <summary>
        /// Gets the player's username.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Creates an instance of the Highscore class, otherwise - returns the existing instance.
        /// </summary>
        /// <returns>The Highscore instance</returns>
        public static IHighscore GetInstance()
        {
            if (instance == null)
            {
                instance = new Highscore();
            }

            return instance;
        }

        /// <summary>
        /// Set Player's Name on demand.
        /// </summary>
        /// <param name="name">The current player's identity.</param>
        /// <returns>Instance of type High score.</returns>
        public IHighscore SetUsername(string name)
        {
            this.Username = name;

            return this;
        }

        /// <summary>
        /// Set Player's Moves
        /// </summary>
        /// <param name="moves">The current player's moves</param>
        /// <returns>The current instance of Highscore</returns>
        public IHighscore SetMoves(int moves)
        {
            this.CurrentMoves = moves;

            return this;
        }

        /// <summary>
        /// Calculates the player's score based on the size of the board and the player's number of moves
        /// </summary>
        /// <param name="boardSize">the size of the board - used in calculating player's final score</param>
        public void SetScore(int boardSize)
        {
            int normalizer = 150;
            int score = (boardSize * TheAnswerToEverything / this.CurrentMoves) * normalizer;

            this.CurrentScore = score;
        }
    }
}
