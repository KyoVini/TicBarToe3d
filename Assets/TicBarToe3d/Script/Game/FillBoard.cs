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
                Color32 newcolor = PlayerManager.Instance.GetCurrentPlayer(_currentPlayer).color;
                objhitted.transform.GetComponent<MeshRenderer>().material.color = newcolor;
                GameDartManager.Instance.CheckRound();
                Board.Instance.BoardStats(objhitted.name);
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
    }
}
    
