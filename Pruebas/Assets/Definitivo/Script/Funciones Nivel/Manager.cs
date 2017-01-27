using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour
{
    [SerializeField]
    public bool nivelMas;

    [SerializeField]
    public static bool muertoGrande=false;
    public static bool muertoPequeño=false;
    GameObject grande;
    GameObject pequeño;

    [SerializeField]
    GameObject alma;


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
                //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
                Debug.Log("Holas");
                GameObject.Find("ActivarInicio").SetActive(false);
                nivelMas = false;
            }
        }
    }    

    void Update()
    {
        if (muertoGrande==true)
        {
            grande.SetActive(false);
            alma.SetActive(true);
            grande.transform.position = Vector3.MoveTowards(grande.transform.position, Movimiento_Grande.checkpointGrande, 10f * Time.deltaTime);

            if (grande.transform.position == Movimiento_Grande.checkpointGrande)
            {
                alma.SetActive(false);
                grande.SetActive(true);
                muertoGrande = false;
            }
        }

        if (muertoPequeño==true)
        {
            pequeño.SetActive(false);
            alma.SetActive(true);
            pequeño.transform.position = Vector3.MoveTowards(pequeño.transform.position, Movimiento_Pequeño.checkpointPequeño, 10f * Time.deltaTime);

             print("hola 1");
            if (pequeño.transform.position == Movimiento_Pequeño.checkpointPequeño)
            {
                print("hola");
                alma.SetActive(false);
                pequeño.SetActive(true);
                muertoPequeño = false;
            }
        }
    }
}
