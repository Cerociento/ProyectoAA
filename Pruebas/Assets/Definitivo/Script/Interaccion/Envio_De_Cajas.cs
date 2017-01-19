using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Envio_De_Cajas : MonoBehaviour 
{
    [SerializeField]
    Transform[] destinoCajasChicas;
    int destinoChicas=0;
    [SerializeField]
    GameObject textoPequeña;

    [SerializeField]
    Transform[] destinoCajasGrandes;
    int destinoGrandes=0;
    [SerializeField]
    GameObject textoGrande;

    [SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip sonidoEnvio;

    void Start()
    {
        textoPequeña.GetComponent<Text>().text = destinoCajasChicas.Length.ToString();
        textoGrande.GetComponent<Text>().text = destinoCajasGrandes.Length.ToString();
    }


    void Update()
    {
        if (destinoChicas >= destinoCajasChicas.Length)
        {
            destinoCajasChicas = new Transform[0];
            
        }

        if (destinoGrandes >= destinoCajasGrandes.Length)
        {
            destinoCajasGrandes = new Transform[0];
        }

       
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.transform.CompareTag("Caja"))
        {
            if (destinoChicas < destinoCajasChicas.Length)
            {
                Debug.Log("Entra Chica");

                hit.transform.position = destinoCajasChicas[destinoChicas].position;
                destinoChicas++;
                textoPequeña.GetComponent<Text>().text = destinoCajasChicas.Length.ToString();

                sonido.PlayOneShot(sonidoEnvio);
            }
        }

        if (hit.transform.CompareTag("Caja Grande"))
        {
            Debug.Log("Entra Grande");

            if (destinoGrandes < destinoCajasGrandes.Length)
            {
                hit.transform.position = destinoCajasGrandes[destinoGrandes].position;
                destinoGrandes++;
				sonido.PlayOneShot(sonidoEnvio);
            }
        }
    }
	

}
