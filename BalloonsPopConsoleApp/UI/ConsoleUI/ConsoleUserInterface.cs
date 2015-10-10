// <copyright  file="ConsoleUserInterface.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.UI.ConsoleUI
{
    using BalloonsPop.UI;
    using BalloonsPop.UI.Drawer;
    using BalloonsPop.UI.InputHandler;

    /// <summary>
    /// Provides common interface that contains both the Input Handler and the Drawer.
    /// </summary>
    public class ConsoleUserInterface : IUserInterface
    {
        /// <summary>
        /// Initializes a new instance of the ConsoleUserInterface class.
        /// </summary>
        public ConsoleUserInterface()
        {
            this.Drawer = new ConsoleDrawer();
            this.Reader = new ConsoleInputHandler();
        }

        /// <summary>
        /// Gets or sets the UI drawer object.
        /// </summary>
        public IPicasso Drawer { get; set; }

        /// <summary>
        /// Gets or sets the Game input handler object.
        /// </summary>
        public IInputHandler Reader { get; set; }
    }
}
