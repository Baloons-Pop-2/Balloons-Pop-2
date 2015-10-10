// <copyright  file="ICommandFactory.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop
{
    using Commands;

    /// <summary>
    /// The interface of the command factory.
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// A factory method for creating commands.
        /// </summary>
        /// <param name="command">The concrete command name.</param>
        /// <returns>An object that implements ICommand.</returns>
        ICommand GetCommand(string command);
    }
}
