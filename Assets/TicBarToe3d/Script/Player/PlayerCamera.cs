using UnityEngine;

namespace TicBarToe3d
{
    public class PlayerCamera : MonoBehaviour, IPlayerCamera
    {
        private Camera playercamera { set; get; }
        [Header ("FOV Setting")]
        [SerializeField] private float maxfov = 75.0f;
        [SerializeField] private float minfov = 46.0f;
        private float aspectRatio;

        [Header("Animation Setting")]
        [SerializeField] private float seconds = 0.3f;

        private float currentsecond;
        private bool animate;
        private float animationstarttime;
        private float initialfov;
        private float finalfov;
        private void Start()
        {
            animate = false;
            playercamera = transform.GetComponent<Camera>();
            aspectRatio = Screen.width / (float)Screen.height;
        }
        public Camera GetCam() => playercamera;
        public Transform GetCamTransform() => transform;
        public void Zoom()
        {
            Animate(minfov, seconds);
        }
        public void PlayerView(float _seconds = 0.1f)
        {
            Animate(maxfov, _seconds);
        }
        private void Animate(float newfieldofview, float _seconds)
        {
            float newfov = 2f * Mathf.Atan(Mathf.Tan(newfieldofview * Mathf.Deg2Rad / 2f) / aspectRatio) * Mathf.Rad2Deg;
            currentsecond = _seconds;
            initialfov = playercamera.fieldOfView;
            finalfov = newfov;
            animationstarttime = Time.time;
            animate = true;
        }
        private void FixedUpdate()
        {
            if (animate)
            {
                float elapsedTime = Time.time - animationstarttime;
                if (elapsedTime < currentsecond)
                {
                    float t = EaseCalculation.EaseOut(elapsedTime / seconds);
                    float currentFOV = Mathf.Lerp(initialfov, finalfov, t);
                    playercamera.fieldOfView = currentFOV;
                }
                else
                {
                    playercamera.fieldOfView = finalfov;
                    animate = false;
                }
            }
        }

    }
}
