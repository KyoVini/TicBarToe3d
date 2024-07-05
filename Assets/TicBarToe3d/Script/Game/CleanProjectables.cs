using UnityEngine;
namespace TicBarToe3d
{
    public class CleanProjectables : MonoBehaviour, INotifier
    {
        Transform projectablesclones;
        void Start()
        {
            projectablesclones = transform;
            GameDartManager.Instance.GetGameClean().Attach(this);
        }
        private void OnDestroy()
        {
            GameDartManager.Instance.GetGameClean().Detach(this);
        }
        public void OnNotify()
        {
            if (projectablesclones != null)
            {
                
                int totalindex = projectablesclones.childCount;
                for (int i = 0; i < totalindex; i++)
                {
                    foreach (Transform child in projectablesclones)
                    {
                        Destroy(child.gameObject);
                    }
                }
            } 
        }
    }
}
