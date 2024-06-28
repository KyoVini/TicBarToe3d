
using UnityEngine;

namespace TicBarToe3d
{
    public static class DrawCondition 
    {
        //verify if the board is full hitted
        public static bool Condition(Board.Square[] squares)
        {
            bool isdraw=true;
            for(int i = 0;i< squares.Length; i++)
            {
                if(squares[i] == null)
                {
                    isdraw =false;
                }
            }
            return isdraw;
        }
    }
}

