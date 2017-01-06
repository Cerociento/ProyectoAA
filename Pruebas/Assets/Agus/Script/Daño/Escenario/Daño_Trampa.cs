using UnityEngine;
using System.Collections;

public class Daño_Trampa : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grande"))
        {
            other.transform.position = Movimiento_Grande.checkpointGrande;
            Pausa.vecesVisto++;
        }

        if (other.CompareTag("Pequeño"))
        {
            other.transform.position = Movimiento_Pequeño.checkpointPequeño;
            Pausa.vecesVisto++;
        }
    }
}
