using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Final : MonoBehaviour 
{
	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip fanfarria;
    [SerializeField]
    GameObject barreraFinalPequeño;
    [SerializeField]
    GameObject barreraFinalGrande;

    [SerializeField]
    GameObject sueloPequeño;
    [SerializeField]
    GameObject sueloGrande;
   
    bool subePequeño;
    bool subeGrande;

    [SerializeField]
    bool finDelJuego;
    bool finNivel;

    void Update()
    {
        if (subePequeño && subeGrande)
        {
            barreraFinalPequeño.SetActive(true);
            barreraFinalGrande.SetActive(true);
            sueloPequeño.transform.Translate(Vector3.up * Time.deltaTime);
            sueloGrande.transform.Translate(Vector3.up * Time.deltaTime);
            MenuFinNivel.prueba = true;
            Timer.tiempoFunciona1 = false;
            finNivel = true;

            if (finDelJuego)
                SceneManager.LoadScene(0);
        }
            
    }

    void OnTriggerStay(Collider other)
    {
        if (!finNivel)
        {
            if (other.CompareTag("Pequeño"))
            {
                if (!subePequeño)
                {
                    other.transform.parent = transform.GetChild(1);
                    subePequeño = true;
                    GameObject.FindWithTag("Grande").transform.Translate(Vector3.up);
                }
            }
            if (other.CompareTag("Grande") || other.CompareTag("Escondido"))
            {
                if (!subeGrande)
                {
                    other.transform.parent = transform.GetChild(1);
                    subeGrande = true;
                    GameObject.FindWithTag("Pequeño").transform.Translate(Vector3.up);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!finNivel)
        {
            if (other.CompareTag("Pequeño"))
            {
                if (subePequeño)
                {
                    other.transform.parent = GameObject.Find("Manager").transform.GetChild(0).GetChild(0);
                    subePequeño = false;
                    GameObject.FindWithTag("Grande").transform.Translate(Vector3.up);
                }
            }
            if (other.CompareTag("Grande") || other.CompareTag("Escondido"))
            {
                if (subeGrande)
                {
                    other.transform.parent = GameObject.Find("Manager").transform.GetChild(0).GetChild(0);
                    subeGrande = false;
                    GameObject.FindWithTag("Pequeño").transform.Translate(Vector3.up);
                }
            }
        }
    }
}
