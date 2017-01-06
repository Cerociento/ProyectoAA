using UnityEngine;
using System.Collections;

public class Coleccionables : MonoBehaviour {


	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Grande")|| col.gameObject.CompareTag("Pequeño"))
        {
			Pausa.recogidos++;
			Destroy(gameObject);
		}
	}
}
