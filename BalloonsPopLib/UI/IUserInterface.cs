// <copyright file="IUserInterface.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop.UI
{
    using Drawer;
    using InputHandler;

    /// <summary>
    /// The interface for the UI.
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Gets the drawer.
        /// </summary>
        IPicasso Drawer { get; }

        /// <summary>
        /// Gets the input handler.
        /// </summary>
        IInputHandler Reader { get; }
    }
}
