using UnityEngine;
using System.Collections;

public class Daño_Trampa : MonoBehaviour 
{
	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip sonidoMuerte;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grande"))
        {
            other.transform.position = Movimiento_Grande.checkpointGrande;
            Pausa.vecesVisto++;
			sonido.PlayOneShot(sonidoMuerte);
        }

        if (other.CompareTag("Pequeño"))
        {
            other.transform.position = Movimiento_Pequeño.checkpointPequeño;
            Pausa.vecesVisto++;
			sonido.PlayOneShot(sonidoMuerte);
        }
    }
}
