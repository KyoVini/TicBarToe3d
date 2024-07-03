using UnityEngine;
namespace TicBarToe3d
{
    public class PlayerView : MonoBehaviour , IGameFlow, IGameShoot
    {
        private CamThrow camthrow;
        private MouseLook mouselook;
        private Transform player;
        void Start()
        {
            camthrow = GetComponent<CamThrow>();
            mouselook = GetComponent<MouseLook>();
            //I dont put the observer here because I dont wanted create 1 more listener and the playermanager is responsable for this one
        }
        public void Init(Transform _player)
        {
            player = _player;
        }
        private void ResetCamtoPlayer()
        {
            camthrow.SetCamPosition(player);
            mouselook.SetLookCenter();
        }
        private void PlayerLook(bool _looking)
        {
            mouselook.Looking(_looking);

        }
        public void OnRoundIntro()
        {
            PlayerLook(false);
        }

        public void OnRoundPlay()
        {
            PlayerLook(true);
        }
        public void OnShoot()
        {
            PlayerLook(false);

        }
        public void OnEndRound()
        {
            ResetCamtoPlayer();
        }

        public void OnEndGame()
        {
            ResetCamtoPlayer();
        }

        
    }
}
    
