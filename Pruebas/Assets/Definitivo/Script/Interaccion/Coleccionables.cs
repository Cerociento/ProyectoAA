using UnityEngine;
using System.Collections;

public class Coleccionables : MonoBehaviour {

	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip sonidoColeccionable;

    CargarGuardar guardar;
    Pausa pausa;

    void Start()
    {
        guardar = GameObject.Find("Manager").GetComponent<CargarGuardar>();
    }

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Grande") || col.gameObject.CompareTag("Pequeño"))
        {
            Pausa.recogidos++;
			sonido.PlayOneShot(sonidoColeccionable);
            GetComponent<BoxCollider>().enabled = false;
            transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false;
            StartCoroutine("GuardarCol");
		}
	}

    IEnumerator GuardarCol()
    {
        yield return new WaitForSeconds(1);
        guardar.Guardar();
        Destroy(gameObject);
    }
}
