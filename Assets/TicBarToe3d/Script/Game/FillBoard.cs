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
                string _currentPlayer = GameDartManager.Instance.currentplayer;
                if (!Board.Instance.SquareIsOcuppied(objhitted.name))
                {
                    Color32 newcolor = PlayerManager.Instance.GetCurrentPlayer(_currentPlayer).color;
                    PaintSquare(objhitted, newcolor);
                    Board.Instance.AddtoBoard(objhitted.name);
                }
                else
                {
                    Board.Instance.CheckHit();
                }
            }
        }
        
        private bool IsProjectableHitBoard(GameObject projectable)
        {
            GameObject _parent = projectable.transform.parent.gameObject;
            if (_parent != null)
            {
                if (_parent == gameObject)
                {
                    return true;

                }
                else
                {
                    return false;
                }
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
    
