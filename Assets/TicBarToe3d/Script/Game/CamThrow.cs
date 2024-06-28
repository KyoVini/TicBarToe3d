using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class CamThrow : MonoBehaviour
    {
        
        private Vector3 resetposition;
        private GameObject projetil;
        public void ChangeCam(GameObject _projetil)
        {
            resetposition = transform.position;
            projetil = _projetil;
            transform.SetParent(projetil.transform);
            transform.GetComponent<MouseLook>().Looking(false);
            Transform newposition = projetil.transform.Find("CamPositon").transform;
            transform.position = newposition.position;
        }
        public void CamCameBack()
        {
            
            transform.SetParent(PlayerManager.Instance.gameObject.transform);
            ResetPosition();
        }
        public void ResetPosition()
        {
            transform.position = resetposition;
        }
        public void Looking(bool _looking)
        {
            transform.GetComponent<MouseLook>().Looking(_looking);
        }
    }
}

