using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour
{
    [SerializeField]
    public bool nivelMas;
    /* [SerializeField]
     GameObject desactivar;*/

    public static bool muertoGrande;
    public static bool muertoPequeño;
    GameObject grande;
    GameObject pequeño;


    void Awake()
    {
        DontDestroyOnLoad(this.transform);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        grande = GameObject.Find("Grande");
        pequeño = GameObject.Find("Pequeño");

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

    void Update()
    {
        if (muertoGrande)
        {
            grande.SetActive(false);
            grande.transform.position = Vector3.MoveTowards(grande.transform.position, Movimiento_Grande.checkpointGrande, 10f * Time.deltaTime);
            if (grande.transform.position == Movimiento_Grande.checkpointGrande)
            {
                grande.SetActive(true);
                muertoGrande = false;
            }
        }

        if (muertoPequeño)
        {
            pequeño.SetActive(false);
            pequeño.transform.position = Vector3.MoveTowards(pequeño.transform.position, Movimiento_Pequeño.checkpointPequeño, 10f * Time.deltaTime);
            if (pequeño.transform.position == Movimiento_Pequeño.checkpointPequeño)
            {
                pequeño.SetActive(true);
                muertoPequeño = false;
            }
        }
    }
}
