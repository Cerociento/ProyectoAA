using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pausa : MonoBehaviour {

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
            pausado = !pausado;
        }

            if (pausado)
            {
                Time.timeScale = 0;
                pausado = true;
                menuPausa.SetActive(true);
                if (nPersonaje == 1)
                {
                    personaje1.SetActive(true);
                    personaje2.SetActive(false);
                }
                else if (nPersonaje == 2)
                {
                    personaje2.SetActive(true);
                    personaje1.SetActive(false);
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
	}
}
