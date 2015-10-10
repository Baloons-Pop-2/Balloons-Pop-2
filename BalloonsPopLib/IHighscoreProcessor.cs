// <copyright  file="IHighscoreProcessor.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The interface of the high scores processor.
    /// </summary>
    public interface IHighscoreProcessor
    {
        /// <summary>
        /// Saves the high score.
        /// </summary>
        /// <param name="highscore">The high score to be saved.</param>
        void SaveHighscore(IHighscore highscore);

        /// <summary>
        /// Returns the top N high scores.
        /// </summary>
        /// <returns>IEnumerable of Tuples that hold the username and the points of the players.</returns>
        IEnumerable<Tuple<string, int>> GetTopHighscores();
    }
}
