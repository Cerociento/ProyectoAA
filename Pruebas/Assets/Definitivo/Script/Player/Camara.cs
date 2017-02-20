using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour
{

    public static Transform Target;
    Transform LugarCamara;

    [SerializeField]
    Transform LugarPequenio;
    [SerializeField]
    Transform LugarGrande;

    [SerializeField]
    Vector3 sitioCamara;

    [SerializeField]
    Transform Grande;
    [SerializeField]
    Transform Pequeño;

    [Range(1,10)]
    [SerializeField]
    float velocidad;

    void Start()
    {
        Target = Pequeño;
        LugarCamara = LugarPequenio;
		Grande.gameObject.GetComponent<Movimiento_Grande>().enabled = false;
		Grande.gameObject.GetComponent<AudioListener>().enabled=false;
    }

    void Update()
    {

       // transform.LookAt(Target);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Target = Pequeño;
            LugarCamara = LugarPequenio;
            //transform.localPosition = sitioCamara;
            //transform.localEulerAngles = Vector3.zero;
            Grande.gameObject.GetComponent<Movimiento_Grande>().enabled = false;
			Grande.gameObject.GetComponent<AudioListener>().enabled=false;
            Pequeño.gameObject.GetComponent<Movimiento_Pequeño>().enabled = true;
			Pequeño.gameObject.GetComponent<AudioListener>().enabled=true;
            Pausa.nPersonaje = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Target = Grande;
            LugarCamara = LugarGrande;        
            //transform.localPosition = sitioCamara;
            //transform.localEulerAngles = Vector3.zero;
            Grande.gameObject.GetComponent<Movimiento_Grande>().enabled = true;
			Grande.gameObject.GetComponent<AudioListener>().enabled=true;
            Pequeño.gameObject.GetComponent<Movimiento_Pequeño>().enabled = false;
			Pequeño.gameObject.GetComponent<AudioListener>().enabled=false;
            Pausa.nPersonaje = 2;
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp (transform.position, LugarCamara.position, Time.deltaTime * velocidad);
        transform.LookAt(Target.position + sitioCamara);
    }
}
