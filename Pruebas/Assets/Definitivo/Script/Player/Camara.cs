using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour
{

    public static Transform Target;
  //  Transform LugarCamara;

    [SerializeField]
    Transform LugarPequenio;
    [SerializeField]
    Transform LugarGrande;

    [SerializeField]
    Vector3 sitioCamara;
    public static Vector3 _sitioCamara = new Vector3(6, 5, 0);
    [SerializeField]
    Vector3 sitioVista;
    public static Vector3 _sitioVista = new Vector3(-16, 4, 0);

    [SerializeField]
    Vector3 sitioCamaraG;
    public static Vector3 _sitioCamaraG = new Vector3(-6, 5, 0);
    [SerializeField]
    Vector3 sitioVistaG;
    public static Vector3 _sitioVistaG = new Vector3(16, 4, 0);

    [SerializeField]
    Transform Grande;
    [SerializeField]
    Transform Pequeño;

    [Range(0.1f,10)]
    [SerializeField]
    float velocidad;
    bool cambio=true;

    public static bool transicion = false;

    [SerializeField]
    bool pruebaCamara;

    void Start()
    {
        Target = Pequeño;
		Grande.gameObject.GetComponent<Movimiento_Grande>().enabled = false;
		Grande.gameObject.GetComponent<AudioListener>().enabled=false;
    }

    void Update()
    {
        if (!pruebaCamara)
        {
            sitioCamara = _sitioCamara;
            sitioVista = _sitioVista;
            sitioCamaraG = _sitioCamaraG;
            sitioVistaG = _sitioVistaG;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cambio = !cambio;
            if (cambio)
            {
                sitioCamara = _sitioCamara;
                sitioVista = _sitioVista;
                Target = Pequeño;
                Grande.gameObject.GetComponent<Movimiento_Grande>().enabled = false;
                Grande.gameObject.GetComponent<AudioListener>().enabled = false;
                Pequeño.gameObject.GetComponent<Movimiento_Pequeño>().enabled = true;
                Pequeño.gameObject.GetComponent<AudioListener>().enabled = true;
                Pausa.nPersonaje = 1;
            }
            else
            {
                sitioCamaraG = _sitioCamaraG;
                sitioVistaG = _sitioVistaG;
                Target = Grande;
                Grande.gameObject.GetComponent<Movimiento_Grande>().enabled = true;
                Grande.gameObject.GetComponent<AudioListener>().enabled = true;
                Pequeño.gameObject.GetComponent<Movimiento_Pequeño>().enabled = false;
                Pequeño.gameObject.GetComponent<AudioListener>().enabled = false;
                Pausa.nPersonaje = 2;
            }
        }
    }

    void LateUpdate()
    {
        if (!transicion)
        {
            if (cambio)
            {
                transform.position = Vector3.Lerp(transform.position, Target.position + sitioCamara, Time.deltaTime * velocidad);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, Target.position + sitioCamaraG, Time.deltaTime * velocidad);
            }
        }

        if (cambio)
        {
            transform.LookAt(LugarPequenio);
        }
        else
        {
            transform.LookAt(LugarGrande);
        }
    }
}
