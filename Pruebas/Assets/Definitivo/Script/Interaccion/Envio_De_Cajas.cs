using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Envio_De_Cajas : MonoBehaviour 
{
    [SerializeField]
    Transform[] destinoCajasChicas;
    int destinoChicas=0;
    [SerializeField]
    Text textoPequeña;

    [SerializeField]
    Transform[] destinoCajasGrandes;
    int destinoGrandes=0;
    [SerializeField]
    Text textoGrande;

    [SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip sonidoEnvio;

    int indiceChicas;
    int indiceGrandes;

    void Start()
    {
        textoPequeña.text =destinoCajasChicas.Length.ToString();
        textoGrande.text = destinoCajasGrandes.Length.ToString();
        indiceChicas = destinoCajasChicas.Length;
        indiceGrandes = destinoCajasGrandes.Length;
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
                hit.transform.position = destinoCajasChicas[destinoChicas].position;
                destinoChicas++;
                indiceChicas--;
                textoPequeña.text = indiceChicas.ToString();
                sonido.PlayOneShot(sonidoEnvio);
            }
        }

        if (hit.transform.CompareTag("Caja Grande"))
        {

            if (destinoGrandes < destinoCajasGrandes.Length)
            {
                hit.transform.position = destinoCajasGrandes[destinoGrandes].position;
                destinoGrandes++;
                indiceGrandes--;
				sonido.PlayOneShot(sonidoEnvio);
                textoGrande.text = indiceGrandes.ToString();
            }
        }
    }
	

}
