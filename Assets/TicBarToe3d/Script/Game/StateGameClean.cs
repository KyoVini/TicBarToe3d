namespace TicBarToe3d
{
    public class StateGameClean : INotifier
    {
        // Start is called before the first frame update
        public StateGameClean()
        {
            GameDartManager.Instance.GetGameRestart().Attach(this);
        }
        public void OnDestroy()
        {
            GameDartManager.Instance.GetGameRestart().Detach(this);
        }
        public void OnNotify()
        {
            Board.Instance.RestartBoard();
        }
    }
}