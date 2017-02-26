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
        Debug.Log(transform.GetChild(0).position);
        
    }

        void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.CompareTag("Grande")|| hit.transform.CompareTag("Pequeño"))
        {
            Debug.Log("Entra");
            rayo.origin = transform.GetChild(0).position;
            rayo.direction = hit.transform.position - rayo.origin;
            if (Physics.Raycast(rayo,out ray/*,ve*/))
            {
                Debug.DrawLine(rayo.origin, rayo.direction, Color.blue,10);
                Debug.Log(ray.collider.name);
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
