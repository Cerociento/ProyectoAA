using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPruebas : MonoBehaviour {

//13-01-2017 AUDIO
	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip hover;
	[SerializeField]
	AudioClip aceptar;

    [SerializeField]
    int level;  

	public void LoadScene(){
		SceneManager.LoadScene(level);
		sonido.PlayOneShot(aceptar);
	}

	public void Salir(){
		Application.Quit();
        Debug.Log("Ha salido del juego");
		sonido.PlayOneShot(aceptar);
	}

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
		sonido.PlayOneShot(aceptar);
    }

	public void OnHover()
	{
		sonido.PlayOneShot(hover);
	}
}
