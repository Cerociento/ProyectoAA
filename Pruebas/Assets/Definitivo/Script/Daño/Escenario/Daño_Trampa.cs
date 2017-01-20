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
            Manager.muertoGrande = true;
            Pausa.vecesVisto++;
            sonido.PlayOneShot(sonidoMuerte);
        }

        if (other.CompareTag("Pequeño"))
        {
            Manager.muertoPequeño = true;
            Pausa.vecesVisto++;
            sonido.PlayOneShot(sonidoMuerte);
        }
    }
}
