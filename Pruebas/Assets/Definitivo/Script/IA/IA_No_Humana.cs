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
            if(Physics.Linecast(transform.GetChild(0).position,target.position,out ray,ve))
            {
                Debug.DrawLine(transform.position, target.position, Color.red,10);   
                if (ray.transform.CompareTag("Grande"))
                {
                    Manager.muertoGrande = true;
                    Pausa.vecesVisto++;
					sonido.PlayOneShot(alarma);
                }

                if (ray.transform.CompareTag("Pequeño"))
                {
                    Manager.muertoPequeño = true;
                    Pausa.vecesVisto++;
					sonido.PlayOneShot(alarma);
                }
            }
        }
    }
}
