using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPops.Traversals
{
    public class TraversalPopperFactory
    {
        private Board board;

        public TraversalPopperFactory(Board board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }

            this.board = board;
        }

        public ITraversalPopper GetPopper(TraversalPattern pattern)
        {
            switch (pattern)
            {
                case TraversalPattern.Default:
                    return new BfsPopper(board);
                default:
                    throw new ArgumentException();
            }
        }

        public void Pop()
        {
            
        }
    }
}
