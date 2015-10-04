using BalloonsPop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopGraphics
{
    public interface IGraphicsBalloon : IVisualizeable
    {
        int Value { get; }
        GraphicsTraversal TraversalEffect { get; }
        bool IsPopped { get; set; }
        void Pop();
        void Unpop();
    }
}
