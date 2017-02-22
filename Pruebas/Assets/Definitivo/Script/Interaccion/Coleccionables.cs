using UnityEngine;
using System.Collections;

public class Coleccionables : MonoBehaviour {

	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip sonidoColeccionable;
    [SerializeField]
    int numPosicionLista;

    ManagerColeccionables coleccionables;
    Pausa pausa;

    void Awake()
    {
        coleccionables = GameObject.Find("Manager").GetComponent<ManagerColeccionables>();
    }

	void OnTriggerEnter(Collider col)              
{
		if(col.gameObject.CompareTag("Grande") || col.gameObject.CompareTag("Pequeño"))
        {
            ManagerColeccionables.coleccion.Coleccionable = gameObject;
            Pausa.recogidos++;
            //coleccionables.InteractuarConLista(numPosicionLista);
            sonido.PlayOneShot(sonidoColeccionable);
            GetComponent<BoxCollider>().enabled = false;
            coleccionables.Extra();
            gameObject.SetActive(false);
           // Destroy(gameObject);
        }
    }
}
