using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPops.Traversals
{
    public interface ITraversalEffect
    {
        void Pop(int row, int col, Board board);
    }
}
