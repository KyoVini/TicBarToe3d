using UnityEngine;

namespace TicBarToe3d
{
    public partial class GameDartManager : MonoBehaviour
    {
        public static GameDartManager instance;

        private PlayerSO player1;
        private PlayerSO player2;
        private string currentplayer;

        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance);
            }
        }
        public void Start()
        {
            player1 = Resources.Load<PlayerSO>("Configs/Player1");
            player2 = Resources.Load<PlayerSO>("Configs/Player2");
            currentplayer = player1.name;
            
        }
        

    }
}

