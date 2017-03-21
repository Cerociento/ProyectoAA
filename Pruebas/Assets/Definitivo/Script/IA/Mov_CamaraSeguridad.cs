using UnityEngine;
using System.Collections;

public class Mov_CamaraSeguridad : MonoBehaviour 
{
    [SerializeField]
    Transform[] target;
    void Update()
    {
        transform.LookAt(target[0]);
    }

}
