using UnityEngine;
using System.Collections;

public class Caja : MonoBehaviour 
{
    public static GameObject caja;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Grande"))
        {
            caja = gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grande"))
        {
            caja = null;
        }
    }
	

}
