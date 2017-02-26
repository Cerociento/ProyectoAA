using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour
{
    [SerializeField]
    public static bool nivelMas;

    public static bool muertoGrande = false;
    public static bool muertoPequeño = false;
    [SerializeField]
    GameObject grandeDañado;
    [SerializeField]
    GameObject pequeñoDañado;
    [SerializeField]
    GameObject alma;
    [SerializeField]
    GameObject creditosFinal;

    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PosicionInicio();
        }

        DontDestroyOnLoad(this.transform);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
            {
            if (nivelMas)
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
                nivelMas = false;
            }
        }
    }

    void Update()
    {       
        if (muertoGrande)
        {
            if (Movimiento_Grande.soltar == false)
            { 
                Movimiento_Grande.soltar = true;
                GameObject.Find("Grande").GetComponent<Movimiento_Grande>().Soltar();
            }  

            alma.transform.position = grandeDañado.transform.position;
            grandeDañado.SetActive(false);
            alma.SetActive(true);
            grandeDañado.transform.parent.parent.position = Vector3.MoveTowards(grandeDañado.transform.parent.parent.position, Movimiento_Grande.checkpointGrande, 10f * Time.deltaTime);
            Caja.caja = null;
            grandeDañado.transform.parent.parent.GetComponent<Rigidbody>().useGravity = false;
            grandeDañado.transform.parent.parent.GetComponent<CapsuleCollider>().enabled = false;
        }

        if (muertoPequeño)
        {
            alma.transform.position = pequeñoDañado.transform.position;
            pequeñoDañado.SetActive(false);
            alma.SetActive(true);
            pequeñoDañado.transform.parent.position = Vector3.MoveTowards(pequeñoDañado.transform.parent.position, Movimiento_Pequeño.checkpointPequeño, 10f * Time.deltaTime);
            pequeñoDañado.transform.parent.GetComponent<Rigidbody>().useGravity = false;
            pequeñoDañado.transform.parent.GetComponent<CapsuleCollider>().enabled = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            creditosFinal.SetActive(false);
        }
    }

    public void PosicionInicio()
    {
        GameObject.FindWithTag("Pequeño").transform.position = new Vector3(0.19f, 0.6f, 1.94f);
        GameObject.FindWithTag("Grande").transform.position = new Vector3(0.2f, 0.6f, -1.88f);
        transform.position = new Vector3(0.61f, 3.16f, 1.23f);
    }
}