using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public static float tiempo=0.0f;
	public float tiempoMuestra=tiempo;
	public static bool tiempoFunciona1;

	// Use this for initialization
	void Start () {
		tiempoFunciona1=true;
	}
	
	// Update is called once per frame
	void Update () {
		if(tiempoFunciona1){
			tiempo+=Time.deltaTime;
	}
}
}
