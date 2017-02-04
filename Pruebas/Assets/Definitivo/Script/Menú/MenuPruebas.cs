﻿using UnityEngine;
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
    bool estamosEnElMenuPrincipal;
    [SerializeField]
    GameObject seguro;

    CargarGuardar cargaGuarda;

    void Awake()
    {
        cargaGuarda = GameObject.Find("Manager").GetComponent<CargarGuardar>();
    }
    void Start()
    {
        ContinuarBoton.transform.GetChild(0).gameObject.SetActive(false);
    }


    void Update()
    {
        if (File.Exists(Application.persistentDataPath + "/monosave.af") && estamosEnElMenuPrincipal)
        {
            //NuevojuegoBoton.transform.localPosition = Vector3.zero;
            ContinuarBoton.GetComponent<Button>().interactable = true;
            ContinuarBoton.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Tiempo jugado " + (int)Timer.tiempoTotal / 60 + " m " + (int)Timer.tiempoTotal % 60.0f + " s";
            ContinuarBoton.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Nivel " + CargarGuardar.NNivel;
        }
        else if(!File.Exists(Application.persistentDataPath + "/monosave.af") && estamosEnElMenuPrincipal)
        {
            //NuevojuegoBoton.transform.position = ContinuarBoton.transform.position;
            ContinuarBoton.GetComponent<Button>().interactable = false;
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
        Timer.tiempoTotal = 0;
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

    public void Reinicio()
    {
        cargaGuarda.Cargar();
    }

	public void OnHover()
	{
		sonido.PlayOneShot(hover);
	}

    public void Seguro()
    {
        if (File.Exists(Application.persistentDataPath + "/monosave.af"))
        {
            seguro.SetActive(true);
        }
        else
        {
            NuevoJuego();
        }

    }
}
