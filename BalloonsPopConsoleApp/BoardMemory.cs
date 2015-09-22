using BalloonsPop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopConsoleApp
{
    public class BoardMemory : IBoardMemory
    {
        public IBoardMemento Memento { get; set; }
    }
}
