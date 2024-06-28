using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class CamThrow : MonoBehaviour
    {
        private GameObject playergobj;
        private Vector3 resetposition;
        private GameObject projetil;
        public void ChangeCam(GameObject _player, GameObject _projetil)
        {
            playergobj = _player;
            resetposition = transform.position;
            projetil = _projetil;
            transform.SetParent(projetil.transform);
            transform.GetComponent<MouseLook>().Looking(false);
            Transform newposition = projetil.transform.Find("CamPositon").transform;
            transform.position = newposition.position;
        }
        public void CamCameBack()
        {
            transform.SetParent(playergobj.transform);
            ResetPosition();
        }
        public void ResetPosition()
        {
            transform.position = resetposition;
            transform.GetComponent<MouseLook>().Looking(true);
            playergobj.transform.GetComponent<ThrowObject>().ResetThrow();
        }
    }
}

