using UnityEngine;
using System.Collections;

public class CamaraSeguridad : MonoBehaviour {

    RaycastHit ray = new RaycastHit();
    [SerializeField]
    Transform target;
   // [SerializeField]
   // GameObject Muerte;

   [SerializeField]
    LayerMask ve;

    void Awake()
    {
        ve = ~((1<<9)|(1<<10));
    }

    void Start()
    {
       // Muerte.SetActive(false);
    }
    void Update()
    {
        target = Camara.Target;
    }

        void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.CompareTag("Grande")|| hit.transform.CompareTag("Pequeño"))
        {
            Debug.Log("Lo ve");
            if(Physics.Linecast(transform.position,target.position,out ray,ve))
            {
             
                Debug.DrawLine(new Vector3(transform.parent.position.x,transform.parent.position.y,transform.parent.position.z), target.position, Color.red, 20);
       
                if (ray.transform.CompareTag("Grande")|| ray.transform.CompareTag("Pequeño"))
                {
                    Debug.Log("Detectado");
                   // Muerte.SetActive(true);

                }
            }
            
        }
    }
 

}
