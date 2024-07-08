using UnityEngine;
namespace TicBarToe3d
{
    public class StateEndRound: INotifier
    {
        public StateEndRound()
        {
            GameDartManager.Instance.GetRoundEnd().Attach(this);
        }
        public void OnDestroy()
        {
            GameDartManager.Instance.GetRoundEnd().Detach(this);
        }
        public void OnNotify()
        {
            PlayerManager.Instance.IgnorePlayerRender(false);
            PlayerManager.Instance.GetCamThrow().SetCamPosition(PlayerManager.Instance.GetPlayer());
            PlayerManager.Instance.GetMouseLook().SetLookCenter();
            PlayerManager.Instance.ChangePlayer();
        }
    }
}