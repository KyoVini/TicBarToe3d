using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class CamThrow : MonoBehaviour
    {
        private Vector3 resetposition;
        private Vector3 resetrotation;

        public void Start()
        {
            resetposition = transform.position;
            resetrotation = transform.eulerAngles;
        }
        public void ChangeCam(GameObject _projetil)
        {
            transform.SetParent(_projetil.transform);
            //transform.GetComponent<MouseLook>().Looking(false);
            Transform newposition = _projetil.transform.Find("CamPositon").transform;
            transform.position = newposition.position;
        }
        public void SetCamPosition(Transform _player)
        {
            transform.SetParent(_player);
            transform.position = resetposition;
            transform.transform.eulerAngles = resetrotation;
        }
    }
}

