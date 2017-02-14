using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class CargaAditiva : MonoBehaviour 
{
    Manager manager;

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pequeño") || other.CompareTag("Grande"))
        {
            if (GetComponent<CargaAditiva>().enabled == true)
            {
                manager.nivelMas = true;
                GetComponent<CargaAditiva>().enabled = false;
            }
        }
    }
	

}
