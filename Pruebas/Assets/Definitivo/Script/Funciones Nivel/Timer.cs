using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public static float tiempo=0.0f;
<<<<<<< HEAD
    public static float tiempoTotal=0.0f;
	public float TNivel;
    public float TTotal;
	public static bool tiempoFunciona1;

    void Awake()
    {
        tiempo = CargarGuardar.TNivel;
        tiempoTotal = CargarGuardar.TTotal;
        print(tiempo);
        print(tiempoTotal);
    }
	// Use this for initialization
	void Start () {
		tiempoFunciona1=true;
        TNivel = tiempo;
        TTotal = tiempoTotal;
    }
=======
	public float tiempoMuestra=tiempo;
	public static bool tiempoFunciona1;

	// Use this for initialization
	void Start () {
		tiempoFunciona1=true;
	}
>>>>>>> origin/master
	
	// Update is called once per frame
	void Update () {
		if(tiempoFunciona1){
<<<<<<< HEAD
			tiempo += Time.deltaTime;
            tiempoTotal += Time.deltaTime;
	   }
        TNivel = tiempo;
        TTotal = tiempoTotal;
    }
=======
			tiempo+=Time.deltaTime;
	}
}
>>>>>>> origin/master
}
