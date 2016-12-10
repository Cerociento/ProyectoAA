using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPruebas : MonoBehaviour {

	[SerializeField]
	GameObject instrucciones;
	[SerializeField]
	GameObject controles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadScene(int level){
		SceneManager.LoadScene(level);
	}

	public void Salir(){
		Application.Quit();
	}

	public void Controles(){
		instrucciones.SetActive(false);
		controles.SetActive(true);
	}

	public void Instrucciones(){
		instrucciones.SetActive(true);
		controles.SetActive(false);
	}
		

}
