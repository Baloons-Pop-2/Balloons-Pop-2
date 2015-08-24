using System;
using BalloonsPops.UI.Drawer;

namespace BalloonsPops.UI.ConsoleUI
{
    class ConsoleDrawer : IPicasso
    {
        public void Draw(object obj)
        {
            Console.WriteLine(obj);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
