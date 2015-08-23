using System;
using System.Collections.Generic;
using BalloonsPops.Traversals;

namespace BalloonsPops
{
    public class BalloonPopManager
    {
        private Board board;
        
        public BalloonPopManager(Board board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }

            this.board = board;
        }

        public void Pop(int row, int col)
        {
            if (!this.board.IsValidPop(row, col))
            {
                throw new IndexOutOfRangeException("out of the board");
            }

            var balloon = this.board[row, col];
            var traversal = balloon.TraversalEffect;
            traversal.Pop(row, col, this.board);
        }
    }
}
