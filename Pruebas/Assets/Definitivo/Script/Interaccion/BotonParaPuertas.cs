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

        for (int i = 0; i < abrePuerta.Length; i++)
            if (activar)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log(i);
                    abrePuerta[i].GetComponent<Animator>().SetTrigger("toggle");
                    abrePuerta[i].GetComponent<BoxCollider>().isTrigger = true;
                    transform.GetChild(1).GetComponent<Renderer>().material.color = Color.green;
                    transform.GetChild(0).GetComponent<MeshFilter>().mesh = botonVerde;
                    transform.GetComponent<BoxCollider>().enabled = false;
					sonido.PlayOneShot(sonidoBoton);
                }
                if(Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Mouse2))
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
}
