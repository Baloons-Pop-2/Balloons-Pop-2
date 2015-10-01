using BalloonsPop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopGraphics
{
    public interface IGraphicsBalloon : IBalloon, IVisualizeable
    {
        int Row { get; set; }
        int Col { get; set; }
    }
}
