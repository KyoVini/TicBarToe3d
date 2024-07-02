using System.Collections;
using UnityEngine;
namespace TicBarToe3d {
    public static class IsGameEnd 
    {
        public static bool Check(Board.Square[] hittedsqures)
        {
            bool endgame = WinCondition.Condition(hittedsqures, Dao.currentplayer);
            bool draw = DrawCondition.Condition(hittedsqures);
            if (!endgame && !draw)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
