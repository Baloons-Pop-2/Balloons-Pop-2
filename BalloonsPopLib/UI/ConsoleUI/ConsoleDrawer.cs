﻿using System;
using BalloonsPop.UI.Drawer;

namespace BalloonsPop.UI.ConsoleUI
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
