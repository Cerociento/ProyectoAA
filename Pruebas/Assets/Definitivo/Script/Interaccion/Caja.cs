using UnityEngine;
using System.Collections;

public class Caja : MonoBehaviour 
{
    public static GameObject caja;

    void Start()
    {
        caja = null;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Grande") || other.CompareTag("Escondido"))
        {
            caja = gameObject;                 
            other.GetComponent<Rigidbody>().Sleep();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grande") || other.CompareTag("Escondido"))
        {
            caja = null;
        }
    }
}
