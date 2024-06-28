using UnityEngine;

namespace TicBarToe3d {
    public class PlayerManager : Singleton <PlayerManager>
    {
        private GameObject playerview;
        public PlayerSO player1;
        public PlayerSO player2;

        private void Start()
        {
            playerview = transform.Find("PlayerView").gameObject;
            player1 = Resources.Load<PlayerSO>("Configs/Player1");
            player2 = Resources.Load<PlayerSO>("Configs/Player2");
        }

        public void PlayerLook(bool _look)
        {
            playerview.GetComponent<MouseLook>().Looking(_look);
        }
        public PlayerSO GetCurrentPlayer(string _name)
        {
            if(_name == player1.name)
            {
                return player1;
            }
            else{
                return player2;
            }
        }
        public string GetNamePlayer(int _player)
        {
            if(_player == 1)
            {
                return player1.name;
            }
            else
            {
                return player2.name;
            }
        }
        
        public void WaittoPlay()
        {
            PlayerLook(false);
        }
        public void ReadytoPlay()
        {
            PlayerLook(true);
        } 
        public void ResetCam()
        {
            transform.Find("PlayerView").GetComponent<CamThrow>().CamCameBack();
        }
    }
}

