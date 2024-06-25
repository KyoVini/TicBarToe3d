using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class ThrowObject : MonoBehaviour
    {
        private Transform cam;
        private Transform attackPoint;
        private GameObject objecttoThrow;

        
        private int totalThrows;
        private float throwCooldown;

        [Header("Throwing")]
        [SerializeField]
        private KeyCode throwKey = KeyCode.Mouse1;

        private float throwForce;
        private float throwUpwardForce;

        private bool readytoThow;

        void Start()
        {
            readytoThow = true;
            cam = gameObject.transform.Find("PlayerView").GetComponent<Camera>().transform;
            attackPoint = gameObject.transform.Find("ThrowPoint").transform;
            objecttoThrow = Resources.Load<GameObject>("Prefabs/Dart");// get later
            
            totalThrows = 5;
            throwCooldown = 0.1f;
            throwForce = 50;
            throwUpwardForce = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(throwKey) && readytoThow && totalThrows > 0)
            {
                Throw();
            }
        }
        private void Throw()
        {
            readytoThow = false;
            GameObject projectile = Instantiate(objecttoThrow, attackPoint.position, cam.rotation);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            Vector3 forceDirection = cam.transform.forward;
            RaycastHit hit;
            if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
            {
                forceDirection = (hit.point - attackPoint.position).normalized;
            }
            Vector3 forcetoAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

            projectileRb.AddForce(forcetoAdd, ForceMode.Impulse);

            totalThrows--;

            Invoke(nameof(ResetThrow), throwCooldown);
        }
        private void ResetThrow()
        {
            readytoThow = true;
        }
    }
}
    
