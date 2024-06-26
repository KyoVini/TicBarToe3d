using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class UIGameDartManager : MonoBehaviour
    {
        public static UIGameDartManager instance;

        private GameObject aim;
        private GameObject hand;

        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance);
            }
        }
        void Start()
        {
            aim = transform.Find("DartUI").gameObject;
            hand = transform.Find("Aim").gameObject;
        }
        public void ShowUI(bool _show)
        {
            aim.SetActive(_show);
            hand.SetActive(_show);
        }

    }
}

