using System.Collections.Generic;
namespace TicBarToe3d
{
    public static class WinCondition
    {
        public static bool Condition(Board.Square[] plays, string player)
        {
            for (int row = 0; row < 3; row++)
            {
                if(plays[3 * row + 0] != null && plays[3 * row + 1]!=null && plays[3 * row + 2]!= null)
                    if (plays[3 * row + 0].player == player && plays[3 * row + 1].player == player && plays[3 * row + 2].player == player)
                    {
                        return true;
                    }
            }

            for (int col = 0; col < 3; col++)
            {
                if (plays[col + 0] != null && plays[col + 3] != null && plays[col + 6] != null)
                    if (plays[col + 0].player == player && plays[col + 3].player == player && plays[col + 6].player == player)
                    {
                        return true;
                    }
            }
            if (plays[0] != null && plays[4] != null && plays[8] != null)
                if (plays[0].player == player && plays[4].player == player && plays[8].player == player)
                {
                    return true;
                }
            if (plays[2] != null && plays[4] != null && plays[6] != null)
                if (plays[2].player == player && plays[4].player == player && plays[6].player == player)
                {
                    return true;
                }

            return false;
        }
       
    }
}

