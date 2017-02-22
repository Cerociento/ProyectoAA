using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Envio_De_Cajas : MonoBehaviour 
{
    [SerializeField]
    Transform[] destinoCajasChicas;
    int destinoChicas=0;

    [SerializeField]
    Transform[] destinoCajasGrandes;
    int destinoGrandes=0;

    [SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip sonidoEnvio;

    [SerializeField]
    Animator anim;

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
                anim.SetTrigger("Suck");
                sonido.PlayOneShot(sonidoEnvio);
            }
        }

        if (hit.transform.CompareTag("Caja Grande"))
        {

            if (destinoGrandes < destinoCajasGrandes.Length)
            {
                hit.transform.position = destinoCajasGrandes[destinoGrandes].position;
                destinoGrandes++;
				sonido.PlayOneShot(sonidoEnvio);
                anim.SetTrigger("Suck");
            }
        }
    }
	

}
