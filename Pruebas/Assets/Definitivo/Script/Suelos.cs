﻿using UnityEngine;
using System.Collections;

public class Suelos : MonoBehaviour {

	[SerializeField]
	GameObject cristal;
	[SerializeField]
	GameObject sueloGrande;
	[SerializeField]
	GameObject sueloPequeño;


	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Grande")|| col.gameObject.CompareTag("Pequeño"))
        {
			cristal.SetActive(true);
			sueloGrande.SetActive(true);
			sueloPequeño.SetActive(true);
		}
	}
}

