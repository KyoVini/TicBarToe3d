using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class MouseLook : MonoBehaviour
    {
        private float mousesensivityY = 170f;
        private float mousesensivityX = 120f;

        private Transform playerbody;
        private float xRotation;

        private bool startlooking = false;
        void Start()
        {
            playerbody = transform.parent.gameObject.transform;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Invoke("Looking", 1.0f);
        }

        // Update is called once per frame
        void Update()
        {
            if (startlooking)
            {
                float mouseX = Input.GetAxis("Mouse X") * mousesensivityX * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mousesensivityY * Time.deltaTime;
                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -60, 60);
                transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
                if (playerbody.name == "Player")
                {
                    playerbody.Rotate(Vector3.up * mouseX);
                }
            }
        }
        private void Looking()
        {
            startlooking = true;
        }
    }
}

