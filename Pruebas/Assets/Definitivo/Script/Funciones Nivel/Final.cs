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

    void Update()
    {
        if (subePequeño && subeGrande)
        {
            sueloPequeño.transform.Translate(Vector3.up * Time.deltaTime);
            sueloGrande.transform.Translate(Vector3.up * Time.deltaTime);
            MenuFinNivel.prueba = true;
            Timer.tiempoFunciona1 = false;

            if (finDelJuego)
                SceneManager.LoadScene(0);
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pequeño"))
        {
            if (!subePequeño)
            {
                barreraFinalPequeño.SetActive(true);
                subePequeño = true;
                GameObject.FindWithTag("Grande").transform.Translate(Vector3.up);              
            }

        }

        if (other.CompareTag("Grande")||other.CompareTag("Escondido"))
        {
            if (!subeGrande)
            {
                barreraFinalGrande.SetActive(true);
                subeGrande = true;
                GameObject.FindWithTag("Pequeño").transform.Translate(Vector3.up);
            }
        }
    }
}
