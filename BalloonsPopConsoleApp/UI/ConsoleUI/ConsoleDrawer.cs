namespace BalloonsPopConsoleApp.UI.ConsoleUI
{
    using System;
    using BalloonsPop.UI.Drawer;

    public class ConsoleDrawer : IPicasso
    {
        public void Draw(object obj)
        {
            Console.Write(obj);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
