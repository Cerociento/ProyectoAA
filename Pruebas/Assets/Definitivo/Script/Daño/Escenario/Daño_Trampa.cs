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
		if (other.CompareTag("Grande")||other.CompareTag("Escondido"))
        {
            Manager.muertoGrande = true;
            //Pausa.vecesVisto++;
            sonido.PlayOneShot(sonidoMuerte);
            other.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (other.CompareTag("Pequeño"))
        {
            Manager.muertoPequeño = true;
            //Pausa.vecesVisto++;
            sonido.PlayOneShot(sonidoMuerte);
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
