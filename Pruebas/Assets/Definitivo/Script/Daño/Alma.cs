using UnityEngine;
using System.Collections;

public class Alma : MonoBehaviour {

    [SerializeField]
    GameObject pequeño,grande;

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            print("alma");
            if (Manager.muertoPequeño)
            {           
                    gameObject.SetActive(false);
                    pequeño.SetActive(true);
                    Manager.muertoPequeño = false;
             }
             else if (Manager.muertoGrande)
             {
                    gameObject.SetActive(false);
                    grande.SetActive(true);
                    Manager.muertoPequeño = false;            
            }
        }
    }
}
