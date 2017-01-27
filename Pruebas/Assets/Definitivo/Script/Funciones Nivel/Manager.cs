using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour
{
    [SerializeField]
    public bool nivelMas;

    public static bool muertoGrande = false;
    public static bool muertoPequeño = false;
    [SerializeField]
    GameObject grandeDañado;
    [SerializeField]
    GameObject pequeñoDañado;

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

        //grandeDañado = GameObject.Find("Grande");
        //pequeñoDañado = GameObject.Find("Pequeño");

    }

    void FixedUpdate()
    {
        if (nivelMas)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
               // GameObject.Find("ActivarInicio").SetActive(false);
                nivelMas = false;
            }
        }
    }

    void Update()
    {
        if (muertoGrande)
        {
            alma.transform.position = grandeDañado.transform.position;
            grandeDañado.SetActive(false);
            alma.SetActive(true);
            grandeDañado.transform.parent.position = Vector3.MoveTowards(grandeDañado.transform.parent.position, Movimiento_Grande.checkpointGrande, 10f * Time.deltaTime);
            grandeDañado.transform.parent.GetComponent<Rigidbody>().useGravity = false;
            grandeDañado.transform.parent.GetComponent<CapsuleCollider>().enabled = false;
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
    }
}