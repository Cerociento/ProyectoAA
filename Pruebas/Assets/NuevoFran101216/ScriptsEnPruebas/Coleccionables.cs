using UnityEngine;
using System.Collections;

public class Coleccionables : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Player")){
			ColeccionablesCuenta.recogidos++;
			Destroy(gameObject);

		}
	}
}
