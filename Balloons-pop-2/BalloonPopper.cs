﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPops
{
    public class BalloonPopper
    {
        private const Balloon EmptyCell = null;
        private Board board;
        private Dictionary<TraversalPattern, Action<int, int, int>> traversalPatterns;

        public BalloonPopper(Board board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }

            this.board = board;

            this.traversalPatterns = new Dictionary<TraversalPattern, Action<int, int, int>>();
            InitializeTraversals();
        }

        

        public void Pop(int row, int col)
        {
            if (!this.board.IndicesAreInRange(row, col))
            {
                throw new IndexOutOfRangeException("out of the board");
            }

            if (this.board[row, col] == EmptyCell)
            {
                throw new ArgumentException("cannot pop emty balloon");
            }

            traversalPatterns[this.board[row, col].TraversalPattern](row, col, this.board[row, col].Value);
            ClearEmptyCells();
        }

        private void InitializeTraversals()
        {
            this.traversalPatterns.Add(TraversalPattern.Default, BfsPop);
        }

        private void BfsPop(int row, int col, int currentCell)
        {
            if (this.board.IndicesAreInRange(row, col) &&
                this.board[row, col] != EmptyCell &&
                this.board[row, col].Value == currentCell)
            {
                this.board[row, col] = EmptyCell;
                
                BfsPop(row - 1, col, currentCell); // Up
                BfsPop(row + 1, col, currentCell); // Down 
                BfsPop(row, col + 1, currentCell); // Left
                BfsPop(row, col - 1, currentCell); // Right
            }
        }

        private void ClearEmptyCells()
        {
            int row;
            int col;

            Queue<Balloon> baloonsToPop = new Queue<Balloon>();
            for (col = this.board.Cols - 1; col >= 0; col--)
            {
                for (row = this.board.Rows - 1; row >= 0; row--)
                {
                    if (this.board[row, col] != EmptyCell)
                    {
                        baloonsToPop.Enqueue(this.board[row, col]);
                        this.board[row, col] = EmptyCell;
                    }
                }

                row = this.board.Rows - 1;
                while (baloonsToPop.Count > 0)
                {
                    this.board[row, col] = baloonsToPop.Dequeue();
                    row--;
                }

                baloonsToPop.Clear();
            }
        }

    }
}