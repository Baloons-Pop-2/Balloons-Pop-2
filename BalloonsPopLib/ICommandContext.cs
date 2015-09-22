using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop
{
    public interface ICommandContext
    {
        IBoard Board { get; }

        int ActiveCol { get; }

        int ActiveRow { get; }

        IBoardMemory Memory { get; }
    }
}
