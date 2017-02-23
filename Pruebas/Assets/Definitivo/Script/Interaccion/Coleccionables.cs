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
		if(col.gameObject.CompareTag("Grande") || col.gameObject.CompareTag("Pequeño") || col.gameObject.CompareTag("Escondido"))
        {
            Pausa.recogidos++;
            ManagerColeccionables.listaGuardar[numPosicionLista] = false;
            sonido.PlayOneShot(sonidoColeccionable);
            coleccionables.Extra();
            gameObject.SetActive(false);
        }
    }
}
