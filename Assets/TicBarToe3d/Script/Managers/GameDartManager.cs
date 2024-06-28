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
            Debug.Log(currentplayer);
            if(currentplayer == null || currentplayer=="")
            {
                currentplayer = PlayerManager.Instance.GetNamePlayer(1);
            }
            PlayerManager.Instance.WaittoPlay();
            UIGameDartManager.Instance.WaittoPlay();
            Invoke(nameof(RoundPlay), 3.0f);
        }
        private void RoundPlay()
        {
            PlayerManager.Instance.ReadytoPlay();
            UIGameDartManager.Instance.ReadtoPlay();
        }
        public void Shoot()
        {
            UIGameDartManager.Instance.Shoot();
        }
        public void HittedBoard(Board.Square[] hittedsqures)
        {
            bool endgame = WinCondition.Condition(hittedsqures, currentplayer);
            bool draw = DrawCondition.Condition(hittedsqures);
            if (!endgame && !draw)
            {
                Invoke(nameof(EndRound), 1.0f);
            }
            else
            {
                Invoke(nameof(EndGame), 1.0f);
            }
        }
        public void EndRound()
        {
            PlayerManager.Instance.ResetCam();
            if (currentplayer == PlayerManager.Instance.GetNamePlayer(1))
            {
                currentplayer = PlayerManager.Instance.GetNamePlayer(2);
            }
            else
            {
                currentplayer = PlayerManager.Instance.GetNamePlayer(1);
            }

            RoundIntro();
        }
        private void EndGame()
        {
            Debug.Log("EndGame");
        }
    }
}

