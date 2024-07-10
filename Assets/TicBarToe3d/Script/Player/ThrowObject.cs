using UnityEngine;

namespace TicBarToe3d
{
    public class ThrowObject : MonoBehaviour
    {
        private Transform cam;
        private CamThrow camthrow;
        private Transform attackPoint;
        private GameObject objecttoThrow;
        private bool zoom;
        

        [Header("Throwing")]
        [SerializeField]
        private KeyCode throwKey = KeyCode.Mouse0;
        [SerializeField]
        private KeyCode zoomKey = KeyCode.Mouse1;

        private float throwForce;
        private float throwUpwardForce;

        private bool readytoThow;

        void Start()
        {
            readytoThow = true;
            zoom = false;
            cam = PlayerManager.Instance.GetPlayerCamera().GetCamTransform();
            camthrow = PlayerManager.Instance.GetCamThrow();
            attackPoint = gameObject.transform.Find("ThrowPoint").transform;
            objecttoThrow = Resources.Load<GameObject>("Prefabs/Dart");
            
            throwForce = 60;
            throwUpwardForce = 0;
        }

        void Update()
        {
            //the interaction change to another classe
            if (Input.GetKeyDown(throwKey) && readytoThow)
            {
                if (zoom)
                {
                    PlayerManager.Instance.GetPlayerCamera().PlayerView();
                    zoom = false;
                }
                Throw();
            }
            if (Input.GetKeyDown(zoomKey) && readytoThow && !zoom)
            {
                PlayerManager.Instance.GetPlayerCamera().Zoom();
                Debug.Log("Zoom clique");
                zoom = true;
            }
            if (Input.GetKeyUp(zoomKey) && readytoThow && zoom)
            {
                PlayerManager.Instance.GetPlayerCamera().PlayerView();
                Debug.Log("Zoom up");
                zoom = false;
            }
            
            
        }
        private void Throw()
        {
            readytoThow = false;
            
            GameObject projectile = Instantiate(objecttoThrow, attackPoint.position, cam.rotation);
            projectile.transform.name = "dartclone";
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            Vector3 forceDirection = cam.forward;
            RaycastHit hit;
            if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
            {
                forceDirection = (hit.point - attackPoint.position).normalized;
            }
            Vector3 forcetoAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

            projectileRb.AddForce(forcetoAdd, ForceMode.Impulse);
            
            camthrow.ChangeCam(projectile);
            GameDartManager.Instance.Shoot();
        }
        public void ResetThrow()
        {
            readytoThow = true;
        }

    }
}
    
