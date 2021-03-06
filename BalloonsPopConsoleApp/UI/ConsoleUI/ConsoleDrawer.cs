﻿// <copyright  file="ConsoleDrawer.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.UI.ConsoleUI
{
    using System;
    using BalloonsPop.UI.Drawer;

    /// <summary>
    /// IPicasso object that takes care of displaying the game objects
    /// </summary>
    public class ConsoleDrawer : IPicasso
    {
        /// <summary>
        /// Draws the string representation of the object passed as a parameter
        /// </summary>
        /// <param name="obj">The object to be drawn</param>
        public void Draw(object obj)
        {
            Console.Write(obj);
        }

        /// <summary>
        /// Clears the window and refreshes the view
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }
    }
}
