using UnityEngine;
using System.Collections;

public class RayoParaTransparencia : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Background"))
        {
            if (other.GetComponent<ParedPersiana>())
                other.GetComponent<ParedPersiana>().persiana = true;          
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Background"))
        {
            if (other.GetComponent<ParedPersiana>())
                other.GetComponent<ParedPersiana>().persiana = false;
        }
    }
}
