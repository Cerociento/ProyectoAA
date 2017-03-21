using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Inicio : MonoBehaviour 
{
    [SerializeField]
    bool unload=false;
    [SerializeField]
    GameObject activar;

    void Update()
    {
        if (unload)
        {
            SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!unload)
        if(other.CompareTag("Finish"))
        {
            GameObject.FindWithTag("Grande").transform.parent = GameObject.Find("Manager").transform.GetChild(0).GetChild(0);
            GameObject.FindWithTag("Pequeño").transform.parent = GameObject.Find("Manager").transform.GetChild(0).GetChild(0);
            MenuFinNivel.prueba = false;
            Timer.tiempoFunciona1 = true;
            Timer.tiempo = 0;
            unload = true;
        }
    }


}
