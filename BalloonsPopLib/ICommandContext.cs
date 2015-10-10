// <copyright  file="ICommandcontext.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop
{
    using System.Collections.Generic;
    using Logs;

    /// <summary>
    /// The interface of the commands context.
    /// </summary>
    public interface ICommandContext
    {
        /// <summary>
        /// Gets the processor for the high scores (saves and loads them from some location).
        /// </summary>
        IHighscoreProcessor HighscoreProcessor { get; }

        /// <summary>
        /// Gets or sets the logger that logs information about the game in some file.
        /// </summary>
        ILogger Logger { get; set; }

        /// <summary>
        /// Gets or sets the board that holds the balloons.
        /// </summary>
        IBoard Board { get; set; }

        /// <summary>
        /// Gets or sets the memento manager.
        /// </summary>
        IBoardMemory Memory { get; set; }

        /// <summary>
        /// Gets or sets the currently played column.
        /// </summary>
        int ActiveCol { get; set; }

        /// <summary>
        /// Gets or sets the currently played row.
        /// </summary>
        int ActiveRow { get; set; }

        /// <summary>
        /// Gets all the messages that are used in the game.
        /// </summary>
        Dictionary<string, string> Messages { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the game is over.
        /// </summary>
        bool IsOver { get; set; }

        /// <summary>
        /// Gets or sets the object that holds the high scores/moves.
        /// </summary>
        IHighscore Score { get; set; }

        /// <summary>
        /// Gets or sets the command output.
        /// </summary>
        string CurrentMessage { get; set; }
    }
}
