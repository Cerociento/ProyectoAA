using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPruebas : MonoBehaviour {

    [SerializeField]
    int level;  

	public void LoadScene(){
		SceneManager.LoadScene(level);
	}

	public void Salir(){
		Application.Quit();
        Debug.Log("Ha salido del juego");
	}

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
