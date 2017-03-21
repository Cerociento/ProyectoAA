using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class CargaAditiva : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pequeño") || other.CompareTag("Grande") || other.CompareTag("Escondido"))
        {
           Final.nivelMas = true;
           GetComponent<CargaAditiva>().enabled = false;
           Destroy(GetComponent<CargaAditiva>());
        }
    }

     
	

}
