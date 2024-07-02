using System.Collections;
using UnityEngine;

namespace TicBarToe3d {
    public class Projectables : MonoBehaviour , IProjectables
    {
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void OnCollisionEnter(Collision collision)
        {
            rb.isKinematic = true;
            Transform newparent = GameDartManager.Instance.transform.Find("ProjectablesClones");
            transform.SetParent(newparent);
            FillBoard.Instance.MarkBoard(collision.transform.gameObject);
        }

    }
}


