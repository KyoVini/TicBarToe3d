using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TicBarToe3d
{
    public class FillBoard : MonoBehaviour
    {
        public static FillBoard instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance);
            }
        }
        public void MarkBoard(GameObject objhitted)
        {
            //verify if the object hitted is the board
        }
        private void IsProjectableHitBoard(GameObject projectable)
        {

        }
    }
}
    
