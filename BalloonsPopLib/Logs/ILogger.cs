// <copyright file="ILogger.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop.Logs
{
    /// <summary>
    /// The interface of the game logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a string somewhere.
        /// </summary>
        /// <param name="operation">The string to be logged.</param>
        void Log(string operation);
    }
}
