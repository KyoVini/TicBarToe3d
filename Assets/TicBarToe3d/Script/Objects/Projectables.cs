using System.Collections;
using UnityEngine;

namespace TicBarToe3d {
    public class Projectables : MonoBehaviour , IProjectables
    {
        private Rigidbody rb;
        private bool targetHit;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (targetHit)
                return;
            else
                targetHit = true;

            rb.isKinematic = true;
            transform.SetParent(collision.transform);

            //Invoke(nameof(ResetCam), 2.0f);
            //---
            FillBoard.Instance.MarkBoard(collision.transform.gameObject);
            //use a callback and in the manager reset the cam resetCam
        }
        private void ResetCam()
        {
            transform.Find("PlayerView").GetComponent<CamThrow>().CamCameBack();
        }

    }
}


