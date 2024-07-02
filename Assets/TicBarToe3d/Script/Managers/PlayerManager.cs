using UnityEngine;

namespace TicBarToe3d {
    public class PlayerManager : Singleton <PlayerManager>, IGameFlow
    {
        private GameObject playerview;
        public PlayerSO player1;
        public PlayerSO player2;
        
        public void Start()
        {
            
            playerview = transform.Find("PlayerView").gameObject;
            player1 = Resources.Load<PlayerSO>("Configs/Player1");
            player2 = Resources.Load<PlayerSO>("Configs/Player2");
        }
        private void OnEnable()
        {
            Debug.Log("Start PlAyer Manaeger");
            GameDartManager.Instance.GetGameStats().Attach(this);
        }
        private void OnDestroy()
        {
            GameDartManager.Instance.GetGameStats().Detach(this);
        }
        public void PlayerLook(bool _look)
        {
            playerview.GetComponent<MouseLook>().Looking(_look);
        }
        public void CamLooking(bool _looking)
        {
            CamThrow camthrow = playerview.GetComponent<CamThrow>(); ;
            camthrow.Looking(_looking);
        }
        public PlayerSO GetCurrentPlayer(string _name)
        {
            if (_name == player1.name)
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
        
        public void ResetCam()
        {
            CamThrow camthrow = playerview.GetComponent<CamThrow>(); ;
            camthrow.CamCameBack();
            camthrow.ResetPosition();
        }
        

        public void OnRoundIntro()
        {
            if (Dao.currentplayer == null || Dao.currentplayer == "")
            {
                Dao.currentplayer = GetNamePlayer(1);
            }
            PlayerLook(false);
        }

        public void OnRoundPlay()
        {
            PlayerLook(true);
            gameObject.transform.GetComponent<ThrowObject>().ResetThrow();
            CamLooking(true);
        }

        public void OnEndRound()
        {
            ResetCam();

            if (Dao.currentplayer == GetNamePlayer(1))
            {
                Dao.currentplayer = GetNamePlayer(2);
            }
            else
            {
                Dao.currentplayer = GetNamePlayer(1);
            }
        }

        public void OnEndGame()
        {
            ResetCam();
        }
    }
}

