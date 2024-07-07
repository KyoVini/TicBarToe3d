using UnityEngine;
namespace TicBarToe3d
{
    public class StateRoundPlay : INotifier
    {
        public StateRoundPlay()
        {
            GameDartManager.Instance.GetRoundPlay().Attach(this);
        }
        public void OnDestroy()
        {
            GameDartManager.Instance.GetRoundPlay().Detach(this);
        }
        public void OnNotify()
        {
            PlayerManager.Instance.GetMouseLook().Looking(true);
            PlayerManager.Instance.GetThrowObject().ResetThrow();

            UIGameDartManager.Instance.GetPlayerView().Visible(true);
            UIGameDartManager.Instance.ShowMessager(false);
        }
    }
}

   
