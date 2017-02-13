using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour
{

    public static Transform Target;

    [SerializeField]
    Vector3 sitioCamara;

    [SerializeField]
    Transform Grande;

    [SerializeField]
    Transform Pequeño;

    [SerializeField]
    float reasignado;


    void Start()
    {
        Target = Pequeño;
        transform.localPosition = sitioCamara;
		Grande.gameObject.GetComponent<Movimiento_Grande>().enabled = false;
		Grande.gameObject.GetComponent<AudioListener>().enabled=false;
    }


    void Update()
    {    
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Target = Pequeño;
            transform.parent = Pequeño;
            transform.localPosition = sitioCamara;
            transform.localEulerAngles = Vector3.zero;
            Grande.gameObject.GetComponent<Movimiento_Grande>().enabled = false;
			Grande.gameObject.GetComponent<AudioListener>().enabled=false;
            Pequeño.gameObject.GetComponent<Movimiento_Pequeño>().enabled = true;
			Pequeño.gameObject.GetComponent<AudioListener>().enabled=true;
            Pausa.nPersonaje = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Target = Grande;            
            transform.parent = Grande;
            transform.localPosition = sitioCamara;
            transform.localEulerAngles = Vector3.zero;
            Grande.gameObject.GetComponent<Movimiento_Grande>().enabled = true;
			Grande.gameObject.GetComponent<AudioListener>().enabled=true;
            Pequeño.gameObject.GetComponent<Movimiento_Pequeño>().enabled = false;
			Pequeño.gameObject.GetComponent<AudioListener>().enabled=false;
            Pausa.nPersonaje = 2;

        }


    }
    void LateUpdate()
    {
        //transform.position = Target.position + sitioCamara;
    }
}
