using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Traversals
{
    public interface ITraversalEffect
    {
        void Pop(int row, int col, IBoard board);
    }
}
