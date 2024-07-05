using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicBarToe3d
{
    public class Board : Singleton<Board> , INotifier
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
            GameDartManager.Instance.GetGameRestart().Attach(this);
        }
        public void AddtoBoard(string _name)
        {
            string player = Dao.currentplayer;
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
        }
        public void CheckHit()
        {
            StartCoroutine(Checking());
        }
        private IEnumerator Checking()
        {
            Debug.Log("CheckHIt");
            bool ended = IsGameEnd.Check(squareshitted);
            if (!ended)
            {
                yield return new WaitForSeconds(1.0f);
                GameDartManager.Instance.EndRound(); 
            }
            else
            {
                yield return new WaitForSeconds(1.0f);
                GameDartManager.Instance.EndGame();
            }
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

        public void OnNotify()
        {
            Array.Clear(squareshitted, 0, squareshitted.Length);
            int totalindex = transform.childCount;
            squareshitted = new Square[totalindex];
            Color32 resetcolor = new Color32(255, 255, 255, 255);
            for (int i = 0; i < totalindex; i++)
            {
                FillBoard.Instance.PaintSquare(transform.GetChild(i).gameObject, resetcolor);
            }
            Dao.currentplayer = PlayerManager.Instance.GetNamePlayer(1);
        }
    }
}

