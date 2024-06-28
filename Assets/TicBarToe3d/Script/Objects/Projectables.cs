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
            //transform.SetParent(collision.transform);
            Transform newparent = GameDartManager.Instance.transform.Find("ProjectablesClones");
            transform.SetParent(newparent);
            FillBoard.Instance.MarkBoard(collision.transform.gameObject);
        }

    }
}


