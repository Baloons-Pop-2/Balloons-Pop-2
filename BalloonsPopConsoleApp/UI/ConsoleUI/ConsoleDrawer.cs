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
        /// <param name="obj"></param>
        public void Draw(object obj)
        {
            Console.Write(obj);
        }

        /// <summary>
        /// Clears the screen of
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }
    }
}
