using UnityEngine;
namespace TicBarToe3d
{
    public class PlayerView : MonoBehaviour , IGameFlow
    {
        private CamThrow camthrow;
        private MouseLook mouselook;
        
        void Start()
        {
            camthrow = GetComponent<CamThrow>();
            mouselook = GetComponent<MouseLook>();
            //posso fazer isso aqui mas vai ter um listener a mais
            //e gera uma "dependencia" adicional do gamedartmanager
            //GameDartManager.Instance.GetGameStats().Attach(this);
        }
        //se n deixar com observar tbm n preciso remover no fim
        /*private void OnDestroy()
        {
            GameDartManager.Instance.GetGameStats().Detach(this);
        }*/
        private void CamLooking(bool _looking)
        {
            camthrow.Looking(_looking);
        }
        private void ResetCamtoPlayer()
        {
            camthrow.SetCamPosition(PlayerManager.Instance.GetTransfrom());
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
            CamLooking(true);
            PlayerLook(true);
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
    
