using UnityEngine;
namespace TicBarToe3d
{
    public class StateRoundIntro : INotifier
    {
        public StateRoundIntro()
        {
            Debug.Log(GameDartManager.Instance + " | " + GameDartManager.Instance.GetRoundIntro() + " | " + this );

            GameDartManager.Instance.GetRoundIntro().Attach(this);
        }
        public void OnDestroy()
        {
            GameDartManager.Instance.GetRoundIntro().Detach(this);
        }
        public void OnNotify()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            PlayerManager.Instance.GetMouseLook().Looking(false);

            UIGameDartManager.Instance.GetPlayerView().Visible(false);
            UIGameDartManager.Instance.GetPlayerScore().ChangeStats(Dao.currentplayer);
            UIGameDartManager.Instance.GetPlayerScore().ChangeStats("show");
            UIGameDartManager.Instance.ShowButton(false);
            UIGameDartManager.Instance.ShowMessager(true);
            UIGameDartManager.Instance.SetMessage(Dao.currentplayer);
        }

        
    }

}
