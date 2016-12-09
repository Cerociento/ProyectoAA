using UnityEngine;
using System.Collections;

public class CogerCaja : MonoBehaviour {
    [SerializeField]
    bool coge;

    void Star()
    {

    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            coge = !coge;
        }
    }

    void OnTriggerStay(Collider hit)
    {
            if (hit.transform.CompareTag("Player"))
            {
                if (coge) { 
                    GetComponent<FixedJoint>().connectedBody = hit.transform.GetComponent<Rigidbody>();               
                }
            else
            {
                GetComponent<FixedJoint>().connectedBody = null;
            }           
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.CompareTag("Player"))
        {
            coge = false;
        }
    }
}
