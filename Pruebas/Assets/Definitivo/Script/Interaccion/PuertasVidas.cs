using UnityEngine;
using System.Collections;

public class PuertasVidas : MonoBehaviour {

    [SerializeField]
    Animator puerta;
    [SerializeField]
    Animator otraPuerta;
    [SerializeField]
    int vidasNecesarias;

	void OnTriggerEnter (Collider other)
    {
    if(other.CompareTag("Pequeño") || other.CompareTag("Escondido") || other.CompareTag("Grande"))
	 if(vidasNecesarias>=Pausa.vecesVisto)
        {
                puerta.GetComponent<Animator>().SetTrigger("toggle");
                otraPuerta.GetComponent<Animator>().SetTrigger("toggle");
                puerta.GetComponent<BoxCollider>().enabled = false;
                otraPuerta.GetComponent<BoxCollider>().enabled = false;
        }
	}
}
