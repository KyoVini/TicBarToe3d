using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TicBarToe3d
{
    public class UIGameDartManager : Singleton<UIGameDartManager>
    {
        private PlayerView playerview;
        private PlayerScore playerscore;
        private GameObject messageround;
        private Button restartbutton;
        void Start()
        {
            messageround = transform.Find("Alert").gameObject;
            playerscore = transform.Find("PlayerScore").gameObject.GetComponent<PlayerScore>();
            playerview = transform.Find("PlayerView").gameObject.GetComponent<PlayerView>();

            restartbutton = transform.Find("Restart_btn").gameObject.GetComponent<Button>();
            restartbutton.onClick.AddListener(RestartAction);

            HideUI();

        }
        public PlayerView GetPlayerView() => playerview;
        public GameObject GetMessager() => messageround;
        public PlayerScore GetPlayerScore() => playerscore;
        
        private void HideUI()
        {
            playerview.Visible(false);
            messageround.SetActive(false);
            restartbutton.transform.gameObject.SetActive(false);
            playerscore.ChangeStats("hide");
        }
        public void ShowButton(bool _visible)
        {
            restartbutton.transform.gameObject.SetActive(_visible);
        }
        public void ShowMessager(bool _visible)
        {
            messageround.SetActive(_visible);
        }
        public void SetMessage(string _message)
        {
            messageround.GetComponent<TextMeshProUGUI>().text = _message;
        }
        void RestartAction()
        {
            GameDartManager.Instance.RestartGame();
        }

    }
}

