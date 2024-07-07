using UnityEngine;

namespace TicBarToe3d {
    public class PlayerManager : Singleton <PlayerManager>
    {
        private PlayerSO player1;
        private PlayerSO player2;

        private MouseLook mouselook;
        private CamThrow camthrow;
        private ThrowObject throwobject;
        
        
        
        private Transform player;
        public void Start()
        {
            player = gameObject.transform;

            mouselook = transform.Find("PlayerView").transform.GetComponent<MouseLook>();
            camthrow = transform.Find("PlayerView").transform.GetComponent<CamThrow>();
            throwobject = gameObject.transform.GetComponent<ThrowObject>();

            player1 = Resources.Load<PlayerSO>("Configs/Player1");
            player2 = Resources.Load<PlayerSO>("Configs/Player2");

            //Could have directly in attached in the game object
            

            Dao.currentplayer = GetNamePlayer(1);
        }

        public MouseLook GetMouseLook() => mouselook;
        public CamThrow GetCamThrow() => camthrow;
        public Transform GetPlayer() => player;
        public ThrowObject GetThrowObject() => throwobject;

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
        public void ChangePlayer()
        {
            if (Dao.currentplayer == GetNamePlayer(1))
            {
                Dao.currentplayer = GetNamePlayer(2);
            }
            else
            {
                Dao.currentplayer = GetNamePlayer(1);
            }
        }
    }
}

