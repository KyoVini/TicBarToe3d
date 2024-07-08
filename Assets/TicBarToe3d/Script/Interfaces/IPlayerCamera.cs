using UnityEngine;

namespace TicBarToe3d
{
    public interface IPlayerCamera
    {
        Camera GetCam();
        Transform GetCamTransform();
        void PlayerView(float _seconds = 0.1f);
        void Zoom();
    }
}