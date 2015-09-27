using System;
using BalloonsPop.UI.Drawer;

namespace BalloonsPopConsoleApp.UI.ConsoleUI
{
    class ConsoleDrawer : IPicasso
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
