// <copyright file="ICommand.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop.Commands
{
    /// <summary>
    /// The interface of the commands.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// The shared interface of the commands that allows polymorphism.
        /// </summary>
        /// <param name="ctx">The game context.</param>
        void Execute(ICommandContext ctx);
    }
}
