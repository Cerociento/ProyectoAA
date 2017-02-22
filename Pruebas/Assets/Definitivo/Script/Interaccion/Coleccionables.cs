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

    void Start()
    {
        coleccionables = GameObject.Find("Manager").GetComponent<ManagerColeccionables>();
        gameObject.SetActive(ManagerColeccionables.listaGuardar[numPosicionLista]);
    }

	void OnTriggerEnter(Collider col)              
{
		if(col.gameObject.CompareTag("Grande") || col.gameObject.CompareTag("Pequeño"))
        {
            Pausa.recogidos++;
            ManagerColeccionables.listaGuardar[numPosicionLista] = false;
            sonido.PlayOneShot(sonidoColeccionable);
            GetComponent<BoxCollider>().enabled = false;
            coleccionables.Extra();
            gameObject.SetActive(false);
        }
    }
}
