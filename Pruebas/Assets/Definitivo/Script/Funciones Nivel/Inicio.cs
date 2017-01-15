using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Inicio : MonoBehaviour 
{
    [SerializeField]
    bool unload;

    void Update()
    {
        if (unload)
        {
            Debug.Log("Hola");
            SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            unload = true;
        }
    }


}
