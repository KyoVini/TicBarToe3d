namespace TicBarToe3d
{
    public class StateRestart : INotifier
    {
        public StateRestart()
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
