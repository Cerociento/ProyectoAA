using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

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

    //Reposicionamiento de personajes
    [SerializeField]
    GameObject Continuar;
    [SerializeField]
    bool estamosEnElMenuPrincipal;
   

    void Update()
    {
        if (File.Exists(Application.persistentDataPath + "/monosave.af") && estamosEnElMenuPrincipal)
        {
            Continuar.GetComponent<Text>().text = "Continuar";
        }
        else if(!File.Exists(Application.persistentDataPath + "/monosave.af") && estamosEnElMenuPrincipal)
        {
            Continuar.GetComponent<Text>().text = "Nuevo Juego";
        }
    }


	public void LoadScene(){
        if(File.Exists(Application.persistentDataPath + "/monosave.af"))
        {
           
            GameObject.Find("Manager").GetComponent<CargarGuardar>().Cargar();          
        }
        else
        {
            SceneManager.LoadScene(1);
        }		
		sonido.PlayOneShot(aceptar);        
	}

    public void MenuPrincipal (){

        SceneManager.LoadScene(0);
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
