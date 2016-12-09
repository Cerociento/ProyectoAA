using UnityEngine;
using System.Collections;

public class CamaraSeguridad : MonoBehaviour {

    RaycastHit ray = new RaycastHit();
    [SerializeField]
    Transform target;
    [SerializeField]
    GameObject Muerte;

    void Awake()
    {
        Muerte = GameObject.Find("Muerte");
    }

    void Start()
    {
        Muerte.SetActive(false);
    }

        void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.CompareTag("Player"))
        {
            Debug.Log("Lo ve");
            if(Physics.Linecast(transform.position,target.position,out ray))
            {
                Debug.Log("Lanza rayo");
                Debug.DrawLine(new Vector3(transform.parent.position.x,transform.parent.position.y,transform.parent.position.z), target.position, Color.red, 20);
                Debug.Log(ray.transform.name);
                if (ray.transform.CompareTag("Player"))
                {
                    Debug.Log("Detectado");
                    Muerte.SetActive(true);

                }
            }
            
        }
    }
 

}
