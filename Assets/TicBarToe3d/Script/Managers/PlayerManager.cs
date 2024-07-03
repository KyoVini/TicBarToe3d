using UnityEngine;

namespace TicBarToe3d {
    public class PlayerManager : Singleton <PlayerManager>, IGameFlow
    {
        private PlayerSO player1;
        private PlayerSO player2;
        private PlayerView playerview;
        public void Start()
        {
            playerview = transform.Find("PlayerView").transform.GetComponent<PlayerView>();
            player1 = Resources.Load<PlayerSO>("Configs/Player1");
            player2 = Resources.Load<PlayerSO>("Configs/Player2");
            Dao.currentplayer = GetNamePlayer(1);
            GameDartManager.Instance.GetGameStats().Attach(this);
        }
        
        private void OnDestroy()
        {
            GameDartManager.Instance.GetGameStats().Detach(this);
        }
        public Transform GetTransfrom()
        {
            return this.transform;
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
        
        
        public void OnRoundIntro()
        {
            playerview.OnRoundIntro();
        }

        public void OnRoundPlay()
        {
            gameObject.transform.GetComponent<ThrowObject>().ResetThrow();
            playerview.OnRoundPlay();
        }

        public void OnEndRound()
        {
            playerview.OnEndRound();
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
            playerview.OnEndGame();
        }
    }
}

