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
    GameObject ContinuarBoton;
    [SerializeField]
    GameObject NuevojuegoBoton;
    [SerializeField]
    bool estamosEnElMenuPrincipal;
   

    void Update()
    {
        if (File.Exists(Application.persistentDataPath + "/monosave.af") && estamosEnElMenuPrincipal)
        {
            NuevojuegoBoton.transform.localPosition = Vector3.zero;
            ContinuarBoton.SetActive(true);
        }
        else if(!File.Exists(Application.persistentDataPath + "/monosave.af") && estamosEnElMenuPrincipal)
        {
            NuevojuegoBoton.transform.position = ContinuarBoton.transform.position;
            ContinuarBoton.SetActive(false);
        }
    }


	public void LoadSceneContinuar(){
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

	public void NuevoJuego (){

		Timer.tiempo=0;
		SceneManager.LoadScene(1);
        GameObject.Find("Manager").GetComponent<CargarGuardar>().Borrar();
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
