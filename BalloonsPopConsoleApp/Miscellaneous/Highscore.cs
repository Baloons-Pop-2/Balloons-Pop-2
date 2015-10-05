namespace BalloonsPopConsoleApp.Miscellaneous
{
    using BalloonsPop;

    /// <summary>
    /// Score object containing information about the player's current moves. Username is set on demand.
    /// </summary>
    public class Highscore : IHighscore
    {
        /// <summary>
        /// Increased each time a player makes a move
        /// </summary>
        public int CurrentScore { get; set; }

        /// <summary>
        /// Player's name. Can be set at any point of the game
        /// </summary>
        public string Username { get; set; }
    }
}
