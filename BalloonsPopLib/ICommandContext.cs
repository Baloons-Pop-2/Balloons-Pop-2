using System.Collections.Generic;
using BalloonsPop.Logs;

namespace BalloonsPop
{
    public interface ICommandContext
    {
        ILogger Logger { get; set; }

        IBoard Board { get; set; }

        IBoardMemory Memory { get; set; }

        int ActiveCol { get; set; }

        int ActiveRow { get; set; }

        Dictionary<string, string> Messages { get; }

        IHighscore Score { get; set; }

        string CurrentMessage { get; set; }
    }
}
