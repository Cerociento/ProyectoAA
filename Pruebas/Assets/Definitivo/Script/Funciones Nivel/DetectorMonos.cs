using UnityEngine;
using System.Collections;

public class DetectorMonos : MonoBehaviour {

	static public bool tiny=false;
	static public bool big=false;
	public bool fTiny=tiny;
	[SerializeField]
	GameObject canvasFinNivel;

	// Use this for initialization
	void Start () {
		canvasFinNivel=GameObject.Find("CanvasFinNivel1");
	}
	
	// Update is called once per frame
	void Update () {
		fTiny=tiny;
		if(tiny&&big){
			MenuFinNivel.prueba=true;
			Timer.tiempoFunciona1=false;
		}else{
			MenuFinNivel.prueba=false;
			Timer.tiempoFunciona1=true;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("DetectorMonos"))
		{
			big=true;
		}
}
}
