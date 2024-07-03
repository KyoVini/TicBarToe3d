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

        private bool startlooking;
        private Quaternion initialcamrotation;
        private Quaternion initialplayerrotation;
        void Start()
        {
            playerbody = transform.parent.gameObject.transform;//player manager obj
            startlooking = false;
            initialcamrotation = transform.localRotation;
            initialplayerrotation = playerbody.rotation;
        }

        // Update is called once per frame
        void Update()
        {
            if (startlooking)
            {
                float mouseX = Input.GetAxis("Mouse X") * mousesensivityX * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mousesensivityY * Time.deltaTime;
                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -60, 40);
                transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
                
                if (playerbody.name == "Player")
                {
                    playerbody.Rotate(Vector3.up * mouseX);
                }
            }
        }
        public void Looking(bool _looking)
        {
            startlooking = _looking;
        }
        public void SetLookCenter()
        {
            xRotation = 0;
            transform.localRotation = initialcamrotation;
            playerbody.rotation = initialplayerrotation;
        }
    }
}

