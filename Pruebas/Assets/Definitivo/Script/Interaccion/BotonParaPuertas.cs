using UnityEngine;
using System.Collections;

public class BotonParaPuertas : MonoBehaviour {

	//AUDIO
	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip sonidoBoton;

    [SerializeField]
    GameObject[] abrePuerta;

    bool activar = false;

    [SerializeField]
    Mesh botonVerde;

    void Update()
    {
            if (activar)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Movimiento_Pequeño._anim.SetTrigger("Pulsado");
                    StartCoroutine("Pulsado");
                }
                if(Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.Mouse0))
                {                   
                    activar = false;
                }
            }
    }
    void OnTriggerEnter(Collider hit)
    {
    if (hit.transform.CompareTag("Pequeño"))
    {
            activar = true;
    }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.transform.CompareTag("Pequeño"))
        {
            activar = false;
        }
    }

    IEnumerator Pulsado()
    {
        yield return new WaitForSeconds(0.6f);
        for (int i = 0; i < abrePuerta.Length; i++)
        {
            abrePuerta[i].GetComponent<Animator>().SetTrigger("toggle");
            abrePuerta[i].GetComponent<BoxCollider>().isTrigger = true;
            transform.GetChild(1).GetComponent<Renderer>().material.color = Color.green;
            transform.GetChild(2).GetComponent<Light>().color = Color.green;
            transform.GetChild(0).GetComponent<MeshFilter>().mesh = botonVerde;
            transform.GetComponent<BoxCollider>().enabled = false;
            sonido.PlayOneShot(sonidoBoton);
        }
    }
}
