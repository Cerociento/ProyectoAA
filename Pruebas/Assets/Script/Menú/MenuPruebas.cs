using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPruebas : MonoBehaviour {

    /*[SerializeField]
	GameObject instrucciones;
	[SerializeField]
	GameObject controles;*/

    [SerializeField]
    int level;  

	public void LoadScene(){
		SceneManager.LoadScene(level);
	}

	public void Salir(){
		Application.Quit();
        Debug.Log("Ha salido del juego");
	}

	/*public void Controles(){
		instrucciones.SetActive(false);
		controles.SetActive(true);
	}

	public void Instrucciones(){
		instrucciones.SetActive(true);
		controles.SetActive(false);
	}*/
		

}
