using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuFinNivel : MonoBehaviour {

	[SerializeField]
	Text vecesDescubierto;
	[SerializeField]
	Text tiempoTardado,tiempoTotal;
  
	[SerializeField]
	static public GameObject texto1;
	[SerializeField]
	GameObject panel;

	public static bool prueba = false;

	void Start () {
        panel.SetActive(false);
	}
	
	void Update () {
		vecesDescubierto.text = "Has perdido " + Pausa.vecesVisto + " veces";
		tiempoTardado.text="Has tardado "+(int)Timer.tiempo/60+" m "+(int)Timer.tiempo%60.0f+" s";
        tiempoTotal.text = "Tiempo jugado " + (int)Timer.tiempoTotal / 60 + " m " + (int)Timer.tiempoTotal % 60.0f + " s";

        if (prueba){
			panel.SetActive(true);
		}else{
			panel.SetActive(false);
		}
	}

	[ContextMenu("Reinicio")]
	void Reiniciar(){
		Timer.tiempo=0;
	}
}
