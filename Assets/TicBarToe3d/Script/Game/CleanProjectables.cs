using UnityEngine;
namespace TicBarToe3d
{
    public class CleanProjectables : Singleton<CleanProjectables>, ICleanProjectables
    {
        Transform projectablesclones;
        void Start()
        {
            Debug.Log("CleanProjectables");
            projectablesclones = transform;
        }
        public void Destroy()
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
