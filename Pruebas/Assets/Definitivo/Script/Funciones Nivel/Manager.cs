using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour
{
    [SerializeField]
    public bool nivelMas;
   /* [SerializeField]
    GameObject desactivar;*/

    void Awake()
    {
        DontDestroyOnLoad(this.transform);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
           // desactivar.SetActive(false);
        }
    }  

    void FixedUpdate()
    {
        if (nivelMas)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
                GameObject.Find("ActivarInicio").SetActive(false);
                nivelMas = false;
            }
        }
    }    

  /*  void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            desactivar.SetActive(false);
        }
        else
        {
            desactivar.SetActive(true);
        }
    }*/
}
