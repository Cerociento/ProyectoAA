using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class CargaAditiva : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pequeño") || other.CompareTag("Grande"))
        {
           Manager.nivelMas = true;
            Debug.Log("Hola  " + Manager.nivelMas);
           GetComponent<CargaAditiva>().enabled = false;
            Destroy(GetComponent<CargaAditiva>());
        }
    }

     
	

}
