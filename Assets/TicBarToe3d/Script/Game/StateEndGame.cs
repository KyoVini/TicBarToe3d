using UnityEngine;
namespace TicBarToe3d
{
    public class StateEndGame : INotifier
    {
        public StateEndGame()
        {
            GameDartManager.Instance.GetGameEnd().Attach(this);
        }
        public void OnDestroy()
        {
            GameDartManager.Instance.GetGameEnd().Detach(this);
        }
        public void OnNotify()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            PlayerManager.Instance.GetCamThrow().SetCamPosition(PlayerManager.Instance.GetPlayer());
            PlayerManager.Instance.GetMouseLook().SetLookCenter();
            UIGameDartManager.Instance.ShowMessager(true);
            UIGameDartManager.Instance.ShowButton(true);
            UIGameDartManager.Instance.GetPlayerScore().ChangeStats("hide");
            UIGameDartManager.Instance.SetMessage(Dao.currentplayer + "<br>Win");
        }
    }
}
