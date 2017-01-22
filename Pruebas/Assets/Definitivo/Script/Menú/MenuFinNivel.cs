using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuFinNivel : MonoBehaviour {

	[SerializeField]
	Text vecesDescubierto;
	[SerializeField]
	Text tiempoTardado;
	[SerializeField]
	static public GameObject texto1;
	[SerializeField]
	GameObject panel;
	public static bool prueba=false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		vecesDescubierto.text = "Has perdido " + Pausa.vecesVisto + " veces";
		tiempoTardado.text="Has tardado "+(int)Timer.tiempo/60+"m"+(int)Timer.tiempo%60.0f+"s";
		if(prueba){
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
