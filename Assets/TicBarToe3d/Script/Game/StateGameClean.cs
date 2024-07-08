namespace TicBarToe3d
{
    public class StateGameClean : INotifier
    {
        // Start is called before the first frame update
        public StateGameClean()
        {
            GameDartManager.Instance.GetGameClean().Attach(this);
        }
        public void OnDestroy()
        {
            GameDartManager.Instance.GetGameClean().Detach(this);
        }
        public void OnNotify()
        {
            CleanProjectables.Instance.Destroy();
            Board.Instance.RestartBoard();
        }
    }
}