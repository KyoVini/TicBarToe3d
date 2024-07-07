using UnityEngine;
using UnityEngine.UI;

namespace TicBarToe3d
{
    public class PlayerScore : MonoBehaviour
    {
        private GameObject player1;
        private GameObject player2;
        void Start()
        {
            player1 = transform.Find("player1").gameObject;
            player1.name = PlayerManager.Instance.GetNamePlayer(1);
            player2 = transform.Find("player2").gameObject;
            player2.name = PlayerManager.Instance.GetNamePlayer(2);
            
        }
        public void ChangeStats(string round)
        {
            switch (round)
            {
                case string name when name == PlayerManager.Instance.GetNamePlayer(1):
                    Hide(true);
                    Selected(player1);
                    NotSelected(player2);
                    break;
                case string name when name == PlayerManager.Instance.GetNamePlayer(2):
                    Hide(true);
                    Selected(player2);
                    NotSelected(player1);
                    break;
                case "hide":
                    Hide(false);
                    break;
                case "show":
                    Hide(true);
                    break;
                default:
                    Debug.Log("Player score stats " + round+" not exits ");
                    break;
            }

        }
        private void Selected(GameObject player)
        {
            PlayerSO currentplayer = PlayerManager.Instance.GetCurrentPlayer(Dao.currentplayer);
            player.GetComponent<Image>().color = currentplayer.color;
        }
        private void NotSelected(GameObject player)
        {
            player.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
        }
        private void Hide(bool _hide)
        {
            gameObject.SetActive(_hide);
        }
    }
}
    
