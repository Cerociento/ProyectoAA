using UnityEngine;
using System.Collections;

public class IA_No_Humana : MonoBehaviour {

	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip alarma;

    Ray rayo;
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
        gameObject.transform.GetChild(0).LookAt(target.position);
    }

    void OnTriggerStay(Collider hit)
    {
        if (hit.transform.CompareTag("Grande")|| hit.transform.CompareTag("Pequeño"))
        {
            rayo.origin = transform.GetChild(0).position;
            rayo.direction = hit.transform.position - rayo.origin;
            if (Physics.Raycast(rayo,out ray,10))
            {
                Debug.DrawRay(rayo.origin, rayo.direction, Color.blue,10);
                if (ray.transform.CompareTag("Grande"))
                {
                    Manager.muertoGrande = true;
                    //Pausa.vecesVisto++;
					sonido.PlayOneShot(alarma);
                }

                if (ray.transform.CompareTag("Pequeño"))
                {
                    Manager.muertoPequeño = true;
                    //Pausa.vecesVisto++;
					sonido.PlayOneShot(alarma);
                }
            }
        }
    }
}
