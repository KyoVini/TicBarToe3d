using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class Board : Singleton<Board>
    {
        List<string> board;
        
        private void Start()
        {
            board = new List<string>();
            int count = gameObject.transform.childCount;
            for(int i= 0; i < count; i++)
            {
                board.Add("");
            }
        }
        // Start is called before the first frame update
        public void BoardStats(string _name)
        {

        }

        
        
    }
}

