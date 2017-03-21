using UnityEngine;
using System.Collections;

public class HijoCaja : MonoBehaviour
{
    Caja caja;

    void Start()
    {
        caja = GetComponentInParent<Caja>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Background"))
        {
            caja.Wall();
        }
    }
}
