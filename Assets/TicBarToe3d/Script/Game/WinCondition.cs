using System.Collections.Generic;
namespace TicBarToe3d
{
    public static class WinCondition
    {
        public static bool Condition(List<int> plays, char player)
        {
            for (int row = 0; row < 3; row++)
            {
                if (plays[3 * row + 0] == player && plays[3 * row + 1] == player && plays[3 * row + 2] == player)
                {
                    return true;
                }
            }

            for (int col = 0; col < 3; col++)
            {
                if (plays[3 * col + 0] == player && plays[3 * col + 1] == player && plays[3 * col + 2] == player)
                {
                    return true;
                }
            }

            if (plays[0] == player && plays[4] == player && plays[8] == player)
            {
                return true;
            }

            if (plays[2] == player && plays[4] == player && plays[6] == player)
            {
                return true;
            }

            return false;
        }
       
    }
}

