using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class CamThrow : MonoBehaviour
    {
        private Vector3 resetposition;
       
        public void ChangeCam(GameObject _projetil)
        {
            resetposition = transform.position;
            transform.SetParent(_projetil.transform);
            transform.GetComponent<MouseLook>().Looking(false);
            Transform newposition = _projetil.transform.Find("CamPositon").transform;
            transform.position = newposition.position;
        }
        public void SetCamPosition(Transform _player)
        {
            transform.SetParent(_player);
            transform.position = resetposition;
        }

        public void Looking(bool _looking)
        {
            transform.GetComponent<MouseLook>().Looking(_looking);
        }
    }
}

