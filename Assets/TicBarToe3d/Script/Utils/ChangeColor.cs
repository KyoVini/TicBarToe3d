using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private Color32 newcolor = new Color32(0,0,0,1);
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = newcolor;
    }

}
