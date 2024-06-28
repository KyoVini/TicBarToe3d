using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TicBarToe3d
{
    [CreateAssetMenu(fileName = "New Player", menuName ="Player")]
    public class PlayerSO : ScriptableObject
    {
        public Color color;
        public string tag;
        public new string name;
    }
}

