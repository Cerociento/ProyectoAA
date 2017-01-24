using UnityEngine;
using System.Collections;

public class Suelos : MonoBehaviour {

	[SerializeField]
	GameObject cristal;
	[SerializeField]
	GameObject sueloGrande;
	[SerializeField]
	GameObject sueloPequeño;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Grande")){
			cristal.SetActive(true);
			sueloGrande.SetActive(true);
			sueloPequeño.SetActive(true);
			Timer.tiempo=0;
			DetectorMonos.big=false;
			DetectorMonos.tiny=false;
		}
	}
}

