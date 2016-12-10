using UnityEngine;
using System.Collections;

public class Pausa : MonoBehaviour {
	public bool pausado;
	[SerializeField]
	public GameObject menuPausa;
	[SerializeField]
	GameObject personaje1;
	[SerializeField]
	GameObject personaje2;
	[SerializeField]
	float nPersonaje;

	// Use this for initialization
	void Start () {
		pausado=false;
		nPersonaje=1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)&&!pausado){
			Time.timeScale=0;
			pausado=true;
			menuPausa.SetActive(true);
			if(nPersonaje==1){
				personaje1.SetActive(true);
				personaje2.SetActive(false);
			}else{
				personaje2.SetActive(true);
				personaje1.SetActive(false);
			}
		}else if(Input.GetKeyDown(KeyCode.P)&&pausado){
			Time.timeScale=1;
			pausado=false;
			menuPausa.SetActive(false);
		}
	}

	public void Despausar(){
		Time.timeScale=1;
		pausado=false;
		menuPausa.SetActive(false);
	}
}
