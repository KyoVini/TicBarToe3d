using UnityEngine;

namespace TicBarToe3d
{
    public class PlayerView : MonoBehaviour
    {
        private GameObject hand;
        private GameObject aim;
        // Start is called before the first frame update
        void Start()
        {
            aim = transform.Find("Aim").gameObject;
            hand = transform.Find("Hand").gameObject;
        }

        public void Visible(bool _visible)
        {
            aim.SetActive(_visible);
            hand.SetActive(_visible);
        }

    }
}
