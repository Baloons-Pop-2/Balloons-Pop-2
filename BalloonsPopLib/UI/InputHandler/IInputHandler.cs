// <copyright file="IInputHandler.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop.UI.InputHandler
{
    /// <summary>
    /// The interface for the input handler.
    /// </summary>
    public interface IInputHandler
    {
        /// <summary>
        /// Reads the input.
        /// </summary>
        /// <returns>The read input.</returns>
        string Read();

        /// <summary>
        /// Parses the input string.
        /// </summary>
        /// <param name="input">the input string to be parsed.</param>
        /// <returns>Parsed commands.</returns>
        string ParseInput(string input);
    }
}
