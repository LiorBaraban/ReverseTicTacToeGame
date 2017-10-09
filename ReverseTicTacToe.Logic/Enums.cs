using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseTicTacToe.Logic
{
    public enum eActionStatus
    {
        Invalid,
        Valid,
        EndGameDraw,
        EndGameDefeat,
        Exit
    }

    public enum eGameTokenValue
    {
        NoToken,
        Player1Token,
        Player2Token
    }
}
