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
            transform.GetComponent<MouseLook>().Startlooking = false;
            Transform newposition = projetil.transform.Find("CamPositon").transform;
            transform.position = newposition.position;
        }
        public void CamCameBack()
        {
            //Here use a manager game to control the reset
            transform.SetParent(playergobj.transform);
            transform.position = resetposition;
            transform.GetComponent<MouseLook>().Startlooking = true;
            playergobj.transform.GetComponent<ThrowObject>().ResetThrow();
        }
    }
}

