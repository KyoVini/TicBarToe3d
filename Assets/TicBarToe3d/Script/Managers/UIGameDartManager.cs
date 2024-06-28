using UnityEngine;
using TMPro;
namespace TicBarToe3d
{
    public class UIGameDartManager : Singleton<UIGameDartManager>
    {
        private GameObject aim;
        private GameObject hand;
        private PlayerScore playerscore;
        private GameObject messageround;

        void Start()
        {
            aim = transform.Find("Hand").gameObject;
            hand = transform.Find("Aim").gameObject;
            messageround = transform.Find("Alert").gameObject;
            playerscore = transform.Find("PlayerScore").gameObject.GetComponent<PlayerScore>();
            HideUI();
        }
        private void HideUI()
        {
            aim.SetActive(false);
            hand.SetActive(false);
            messageround.SetActive(false);
            playerscore.ChangeStats("hide");
        }
        public void Shoot()
        {
            hand.SetActive(false);
            aim.SetActive(false);
        }
        public void WaittoPlay()
        {
            aim.SetActive(false);
            hand.SetActive(false);
            messageround.SetActive(true);
            messageround.GetComponent<TextMeshProUGUI>().text = GameDartManager.Instance.currentplayer;
            playerscore.ChangeStats(GameDartManager.Instance.currentplayer);
        }
        public void ReadtoPlay()
        {
            aim.SetActive(true);
            hand.SetActive(true);
            messageround.SetActive(false);
        }
    }
}

