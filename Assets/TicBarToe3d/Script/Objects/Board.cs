using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class Board : Singleton<Board>
    {
        private string[] boardname;
        public class Square
        {
            public string name  { set ; get; }
            public string player { set; get; }
        }
        private Square[] squareshitted;
        public void Start()
        {
            int totalindex = transform.childCount;
            boardname = new string[totalindex];
            for (int i =0; i< totalindex; i++)
            {
                boardname[i]=transform.GetChild(i).transform.name;
            }
            squareshitted = new Square[totalindex];
        }
        public void AddtoBoard(string _name,string player)
        {
            for (int i = 0; i< boardname.Length; i++)
            {
                if(boardname[i] == _name)
                {
                    Square square = new Square();
                    square.name = _name;
                    square.player = player;
                    squareshitted[i] = square;
                }
            }
            GameDartManager.Instance.HittedBoard(squareshitted);
        }
        public bool SquareIsOcuppied(string namesquare)
        {
            for(int i =0;i< squareshitted.Length; i++)
            {
                if(squareshitted[i] != null )
                    if(squareshitted[i].name == namesquare)
                    {
                        return true;
                    }
            }
            return false;
        }

    }
}

