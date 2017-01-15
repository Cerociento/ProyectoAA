using UnityEngine;
using System.Collections;

public class Coleccionables : MonoBehaviour {

	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip sonidoColeccionable;

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Grande")|| col.gameObject.CompareTag("Pequeño"))
        {
			Pausa.recogidos++;
			sonido.PlayOneShot(sonidoColeccionable);
			Destroy(gameObject);
		}
	}
}
