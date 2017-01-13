using UnityEngine;
using System.Collections;

public class IA_No_Humana : MonoBehaviour {

	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip alarma;

    RaycastHit ray = new RaycastHit();
    [SerializeField]
    Transform target;

   [SerializeField]
    LayerMask ve;

    void Awake()
    {
        ve = ~((1<<9)|(1<<10));
        target = Camara.Target;
    }

    void Update()
    {
        target = Camara.Target;
    }

        void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.CompareTag("Grande")|| hit.transform.CompareTag("Pequeño"))
        {
            if(Physics.Linecast(transform.position,target.position,out ray,ve))
            {
                Debug.Log(gameObject.name);       
                if (ray.transform.CompareTag("Grande"))
                {
                    target.transform.position = Movimiento_Grande.checkpointGrande;
                    Pausa.vecesVisto++;
					sonido.PlayOneShot(alarma);
                }

                if (ray.transform.CompareTag("Pequeño"))
                {
                    target.transform.position = Movimiento_Pequeño.checkpointPequeño;
                    Pausa.vecesVisto++;
					sonido.PlayOneShot(alarma);
                }
            }
        }
    }
}
