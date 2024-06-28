using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TicBarToe3d
{
    public class UIGameDartManager : Singleton<UIGameDartManager>
    {
        private GameObject aim;
        private GameObject hand;
        private PlayerScore playerscore;
        private GameObject messageround;
        private Button restartbutton;
        void Start()
        {
            aim = transform.Find("Hand").gameObject;
            hand = transform.Find("Aim").gameObject;
            messageround = transform.Find("Alert").gameObject;
            restartbutton = transform.Find("Restart_btn").gameObject.GetComponent<Button>();
            restartbutton.onClick.AddListener(RestartAction);
            playerscore = transform.Find("PlayerScore").gameObject.GetComponent<PlayerScore>();
            
            HideUI();
        }
        private void HideUI()
        {
            aim.SetActive(false);
            hand.SetActive(false);
            messageround.SetActive(false);
            restartbutton.transform.gameObject.SetActive(false);
            playerscore.ChangeStats("hide");
        }
        public void WaittoPlay()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            aim.SetActive(false);
            hand.SetActive(false);
            messageround.SetActive(true);
            restartbutton.transform.gameObject.SetActive(false);
            messageround.GetComponent<TextMeshProUGUI>().text = GameDartManager.Instance.currentplayer;
            playerscore.ChangeStats(GameDartManager.Instance.currentplayer);
        }
        public void ReadtoPlay()
        {
            aim.SetActive(true);
            hand.SetActive(true);
            messageround.SetActive(false);
        }
        public void Shoot()
        {
            hand.SetActive(false);
            aim.SetActive(false);
        }
        public void EndGame() {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            messageround.SetActive(true);
            restartbutton.transform.gameObject.SetActive(true);
            messageround.GetComponent<TextMeshProUGUI>().text = GameDartManager.Instance.currentplayer +"<br>Win" ;
        }
        void RestartAction()
        {
            GameDartManager.Instance.RestartGame();
        }
    }
}

