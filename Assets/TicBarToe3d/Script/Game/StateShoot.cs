using UnityEngine;
namespace TicBarToe3d
{
    public class StateShoot : INotifier
    {
        public StateShoot()
        {
            GameDartManager.Instance.GetGameShoot().Attach(this);
        }
        public void OnDestroy()
        {
            GameDartManager.Instance.GetGameShoot().Detach(this);
        }
        public void OnNotify()
        {
            PlayerManager.Instance.GetMouseLook().Looking(false);
            PlayerManager.Instance.IgnorePlayerRender(true);
            UIGameDartManager.Instance.GetPlayerView().Visible(false);
        }
    }
}