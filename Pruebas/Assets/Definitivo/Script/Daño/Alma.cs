using UnityEngine;
using System.Collections;

public class Alma : MonoBehaviour {

    [SerializeField]
    GameObject pequeño,grande;

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            if (Manager.muertoPequeño)
            {           
                    gameObject.SetActive(false);
                    pequeño.SetActive(true);
                    Manager.muertoPequeño = false;
                    pequeño.transform.parent.GetComponent<CapsuleCollider>().enabled = true;
                    pequeño.transform.parent.GetComponent<Rigidbody>().useGravity = true;
            }
             else if (Manager.muertoGrande)
             {
                    gameObject.SetActive(false);
                    grande.SetActive(true);
                    Manager.muertoGrande = false;
                    grande.transform.parent.GetComponent<CapsuleCollider>().enabled = true;
                    grande.transform.parent.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
