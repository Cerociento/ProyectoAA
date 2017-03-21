using UnityEngine;
using System.Collections;

public class EnemigoMatar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Grande")||other.CompareTag("Escondido"))
	{
		Manager.muertoGrande = true;
		//Pausa.vecesVisto++;
	}

	if (other.CompareTag("Pequeño"))
	{
		Manager.muertoPequeño = true;
		//Pausa.vecesVisto++;
	}
}
}

