using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPruebas : MonoBehaviour {

    [SerializeField]
    int level;
	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip hover;
	[SerializeField]
	AudioClip aceptar;

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
