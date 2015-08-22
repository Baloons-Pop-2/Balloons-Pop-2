using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonsPops.Traversals;

namespace BalloonsPops
{
    public class BalloonPopManager
    {
        private Board board;
        private Dictionary<TraversalPattern, ITraversalPopper> traversalPatterns;
        private TraversalPattern[] patternsList;
        private TraversalPopperFactory popperFactory;
        

        public BalloonPopManager(Board board, TraversalPattern[] traversalPatterns)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }

            this.board = board;
            this.patternsList = traversalPatterns;

            this.popperFactory = new TraversalPopperFactory(board);
            this.traversalPatterns = new Dictionary<TraversalPattern, ITraversalPopper>();
            InitializeTraversals();
        }

        public void Pop(int row, int col)
        {
            if (!this.board.IsValidPop(row, col))
            {
                throw new IndexOutOfRangeException("out of the board");
            }

            var balloon = this.board[row, col];

            traversalPatterns[balloon.TraversalPattern].Pop(row, col);
        }

        private void InitializeTraversals()
        {
            foreach (var pattern in this.patternsList)
            {
                if (!this.traversalPatterns.ContainsKey(pattern))
                {
                    this.traversalPatterns.Add(pattern, popperFactory.GetPopper(pattern));
                }
            }
        }
    }
}
