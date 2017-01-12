using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class CargaAditiva : MonoBehaviour 
{
    Manager manager;

    void Start()
    {
        manager = GameObject.Find("Manager (Principal)").GetComponent<Manager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pequeño") || other.CompareTag("Grande"))
        {
            // manager.LoadAdditive();
            manager.nivelMas = true;
            Destroy(gameObject);
        }
    }
	

}
