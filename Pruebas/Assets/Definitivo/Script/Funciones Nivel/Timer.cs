using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public static float tiempo=0.0f;
    public static float tiempoTotal=0.0f;
	public float TNivel;
    public float TTotal;
	public static bool tiempoFunciona1;

    void Awake()
    {
        
    }
	// Use this for initialization
	void Start () {
        tiempo = CargarGuardar.TNivel;
        tiempoTotal = CargarGuardar.TTotal;
        tiempoFunciona1 =true;
        TNivel = tiempo;
        TTotal = tiempoTotal;
    }
	
	// Update is called once per frame
	void Update () {
        if (tiempoFunciona1){
			tiempo += Time.deltaTime;
            tiempoTotal += Time.deltaTime;
	   }
        TNivel = tiempo;
        TTotal = tiempoTotal;
    }
}
