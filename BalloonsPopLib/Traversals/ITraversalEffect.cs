// <copyright file="ITraversalEffect.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop.Traversals
{
    /// <summary>
    /// The interface of the traversal effects.
    /// </summary>
    public interface ITraversalEffect
    {
        /// <summary>
        /// Pops the balloons on the board according to their traversal effect.
        /// </summary>
        /// <param name="row">The row on which is the balloon.</param>
        /// <param name="col">The column on which is the balloon.</param>
        /// <param name="board">The board of the game.</param>
        void Pop(int row, int col, IBoard board);
    }
}
