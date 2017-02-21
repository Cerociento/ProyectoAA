﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pausa : MonoBehaviour {

	//Audio 13-01-2017
	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip sonidoPausa;
	[SerializeField]
	AudioClip sonidoSeleccion;


    //Pausa
	public bool pausado;
	[SerializeField]
	public GameObject menuPausa;
	[SerializeField]
	GameObject personaje1;
	[SerializeField]
	GameObject personaje2;
    public static int nPersonaje;

    //Veces Muerto
    public static int vecesVisto;
    [SerializeField]
    Text textoMuerto;

    //Coleccionables
    [SerializeField]
    Text textoColeccionable;
    [SerializeField]
    int coleccionables;
    [SerializeField]
    [Range(0, 50)]
    public static int recogidos;

    void Start () {
		pausado=false;
		nPersonaje=1;
	}

    void Update()
    {
        textoMuerto.text = "Has perdido " + vecesVisto + " veces";

        textoColeccionable.text = recogidos + " / " + coleccionables;

        if (Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown(KeyCode.Escape))
        {
			sonido.PlayOneShot(sonidoPausa);
            pausado = !pausado;
			if(MenuFinNivel.prueba){
				MenuFinNivel.prueba=false;
			}
        }

            if (pausado)
            {
                Time.timeScale = 0;
                pausado = true;
                menuPausa.SetActive(true);
                if (nPersonaje == 1)
                {
                    personaje1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    personaje2.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
                }
                else if (nPersonaje == 2)
                {
                   personaje2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                   personaje1.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
                }
            }
            else
            {
                Time.timeScale = 1;
                pausado = false;
                menuPausa.SetActive(false);
            }       
    }
	public void Despausar(){
		Time.timeScale=1;
		pausado=false;
		menuPausa.SetActive(false);
        sonido.PlayOneShot(sonidoPausa);
    }

	public void OnHover(){
		sonido.PlayOneShot(sonidoSeleccion);
	}
}
