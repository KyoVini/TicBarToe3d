using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TicBarToe3d
{
    public class FillBoard : Singleton<FillBoard>
    {
        public void MarkBoard(GameObject objhitted)
        {
            if (IsProjectableHitBoard(objhitted))
            {
                string _currentPlayer = Dao.currentplayer;
                if (!Board.Instance.SquareIsOcuppied(objhitted.name))
                {
                    Color32 newcolor = PlayerManager.Instance.GetCurrentPlayer(_currentPlayer).color;
                    PaintSquare(objhitted, newcolor);
                    Board.Instance.AddtoBoard(objhitted.name);
                }
            }
            Board.Instance.CheckHit();
        }
        
        private bool IsProjectableHitBoard(GameObject projectable)
        {
            if (projectable.transform.parent.gameObject == gameObject)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void PaintSquare(GameObject obj, Color32 newcolor)
        {
            obj.transform.GetComponent<MeshRenderer>().material.color = newcolor;
        }

    }
}
    
