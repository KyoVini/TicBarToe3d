using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TicBarToe3d
{
    public class UIGameDartManager : Singleton<UIGameDartManager>, INotifier
    {
        private GameObject aim;
        private GameObject hand;
        private PlayerScore playerscore;
        private GameObject messageround;
        private Button restartbutton;
        void Start()
        {
            aim = transform.Find("Aim").gameObject;
            hand = transform.Find("Hand").gameObject;
            messageround = transform.Find("Alert").gameObject;
            restartbutton = transform.Find("Restart_btn").gameObject.GetComponent<Button>();
            restartbutton.onClick.AddListener(RestartAction);
            playerscore = transform.Find("PlayerScore").gameObject.GetComponent<PlayerScore>();
            HideUI();
            GameDartManager.Instance.GetGameStats().Attach(this);
            GameDartManager.Instance.GetShoot().Attach(this);

        }
        private void OnDestroy()
        {
            GameDartManager.Instance.GetGameStats().Detach(this);
            GameDartManager.Instance.GetShoot().Detach(this);
        }
        
        private void HideUI()
        {
            aim.SetActive(false);
            hand.SetActive(false);
            messageround.SetActive(false);
            restartbutton.transform.gameObject.SetActive(false);
            playerscore.ChangeStats("hide");
        }
        
        
        void RestartAction()
        {
            //could became a event call
            GameDartManager.Instance.RestartGame();
        }

        public void OnRoundIntro()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            aim.SetActive(false);
            hand.SetActive(false);
            messageround.SetActive(true);
            restartbutton.transform.gameObject.SetActive(false);
            messageround.GetComponent<TextMeshProUGUI>().text = Dao.currentplayer;
            playerscore.ChangeStats(Dao.currentplayer);
            playerscore.ChangeStats("show");
        }

        public void OnRoundPlay()
        {
            aim.SetActive(true);
            hand.SetActive(true);
            messageround.SetActive(false);
        }
        public void OnNotify()
        {
            hand.SetActive(false);
            aim.SetActive(false);
            
        }
        public void OnEndRound()
        {
            //wait to implement
        }

        public void OnEndGame()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            messageround.SetActive(true);
            restartbutton.transform.gameObject.SetActive(true);
            playerscore.ChangeStats("hide");
            messageround.GetComponent<TextMeshProUGUI>().text = Dao.currentplayer + "<br>Win";
        }

    }
}

