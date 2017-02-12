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
            if (finDelJuego)
            {
                Timer.tiempoFunciona1 = false;
                SceneManager.LoadScene(0);
                finNivel = true;
            }
            else
            { 
                 barreraFinalPequeño.SetActive(true);
                 barreraFinalGrande.SetActive(true);
                 sueloPequeño.transform.Translate(Vector3.up*2 * Time.deltaTime);
                 sueloGrande.transform.Translate(Vector3.up *2* Time.deltaTime);
                 MenuFinNivel.prueba = true;
                 Timer.tiempoFunciona1 = false;
                 finNivel = true;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!finNivel && !finDelJuego)
        {
            if (other.CompareTag("Pequeño"))
            {
                if (!subePequeño)
                {
                    other.transform.parent = transform.GetChild(1);
                    subePequeño = true;
                    GameObject.FindWithTag("Grande").transform.Translate(Vector3.up*2);
                }
            }
            if (other.CompareTag("Grande") || other.CompareTag("Escondido"))
            {
                if (!subeGrande)
                {
                    other.transform.parent = transform.GetChild(1);
                    subeGrande = true;
                    GameObject.FindWithTag("Pequeño").transform.Translate(Vector3.up*2);
                }
            }
        }
        else
        { 
        if (other.CompareTag("Pequeño"))
            if (!subePequeño)
            {
                subePequeño = true;
            }

         if (other.CompareTag("Grande") || other.CompareTag("Escondido"))
            if (!subeGrande)
            {
                subeGrande = true;
            }
         }
    }

    void OnTriggerExit(Collider other)
    {
        if (!finNivel && !finDelJuego)
        {
            if (other.CompareTag("Pequeño"))
            {
                if (subePequeño)
                {
                    other.transform.parent = GameObject.Find("Manager").transform.GetChild(0).GetChild(0);
                    subePequeño = false;
                    GameObject.FindWithTag("Grande").transform.Translate(Vector3.up*2);
                }
            }
            if (other.CompareTag("Grande") || other.CompareTag("Escondido"))
            {
                if (subeGrande)
                {
                    other.transform.parent = GameObject.Find("Manager").transform.GetChild(0).GetChild(0);
                    subeGrande = false;
                    GameObject.FindWithTag("Pequeño").transform.Translate(Vector3.up*2);
                }
            }
        }
    }
}
