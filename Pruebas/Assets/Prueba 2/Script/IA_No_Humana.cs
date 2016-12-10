using UnityEngine;
using System.Collections;

public class IA_No_Humana : MonoBehaviour {

    RaycastHit ray = new RaycastHit();
    [SerializeField]
    Transform target;

   [SerializeField]
    LayerMask ve;

    void Awake()
    {
        ve = ~((1<<9)|(1<<10));
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
                Debug.DrawLine(new Vector3(transform.GetChild(0).position.x,transform.GetChild(0).position.y,transform.GetChild(0).position.z), target.position, Color.red, 20);
       
                if (ray.transform.CompareTag("Grande"))
                {
                    target.transform.position = Movimiento_Grande.checkpoint;
                }

                if (ray.transform.CompareTag("Pequeño"))
                {
                    target.transform.position = Movimiento_Pequeño.checkpoint;
                }
            }
        }
    }
}
