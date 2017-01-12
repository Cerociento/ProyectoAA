using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour 
{

    public bool nivelMas;

    void Awake()
    {
        DontDestroyOnLoad(this.transform);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

     public void LoadAdditive()
    {

       /* if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
        }*/
    }	  
    
    void FixedUpdate()
    {
        if (nivelMas)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);               
                nivelMas = false;
            }
        }
    } 

}
