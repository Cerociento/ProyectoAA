using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Inicio : MonoBehaviour 
{
    [SerializeField]
    bool unload;
    [SerializeField]
    GameObject activar;

    void Update()
    {
        if (unload)
        {
            SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
            //GameObject.Find("ActivarInicio").SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            unload = true;
            MenuFinNivel.prueba = false;
            Timer.tiempoFunciona1 = true;
            Timer.tiempo = 0;
        }
    }


}
