using UnityEngine;
using System.Collections;

public class pruebaPatrulla : MonoBehaviour {

	[SerializeField]
	Transform[] ruta;
	int puntoDeRuta;
	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.autoBraking=false;
		SiguientePunto();
	}

	void SiguientePunto(){
		if(ruta.Length==0){
			return;
	}
		agent.destination=ruta[puntoDeRuta].position;
		puntoDeRuta=(puntoDeRuta+1)%ruta.Length;
}

	void Update(){
		if(agent.remainingDistance<0.5f){
			SiguientePunto();
		}
	}
}
