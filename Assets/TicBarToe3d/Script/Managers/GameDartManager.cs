using UnityEngine;

namespace TicBarToe3d
{
    public class GameDartManager : Singleton<GameDartManager>
    {
        public string currentplayer;
        public void Start()
        {
            IntroGame();
        }
        private void IntroGame()
        {
            Invoke(nameof(RoundIntro), 0.1f);
            //cam fly around the scene and get the player vision
        }
        private void RoundIntro()
        {
            currentplayer = PlayerManager.Instance.GetNamePlayer(1);
            PlayerManager.Instance.WaittoPlay();
            UIGameDartManager.Instance.WaittoPlay();
            Invoke(nameof(RoundPlay), 3.0f);
        }
        private void RoundPlay()
        {
            PlayerManager.Instance.ReadytoPlay();
            UIGameDartManager.Instance.ReadtoPlay();
        }
        public void EndRound()
        {

        }
        public void CheckRound()
        {

            //WinCondition.Condition();
            //change player
            if (currentplayer == PlayerManager.Instance.GetNamePlayer(1))
            {
                currentplayer = PlayerManager.Instance.GetNamePlayer(2);
            }
            else
            {
                currentplayer = PlayerManager.Instance.GetNamePlayer(1);
            }
        }
        private void EndGame()
        {
            
        }
    }
}

