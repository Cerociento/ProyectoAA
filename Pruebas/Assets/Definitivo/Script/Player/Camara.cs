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

    void Start()
    {
        Target = Pequeño;
        sitioCamara = transform.position - Target.position;
        Pequeño.gameObject.GetComponent<Movimiento_Grande>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Target = Grande;
            transform.position = Target.position + sitioCamara;
            Grande.gameObject.GetComponent<Movimiento_Grande>().enabled = true;
            Pequeño.gameObject.GetComponent<Movimiento_Pequeño>().enabled = false;
            Pausa.nPersonaje = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Target = Pequeño;
            transform.position = Target.position + sitioCamara;
            Grande.gameObject.GetComponent<Movimiento_Grande>().enabled = false;
            Pequeño.gameObject.GetComponent<Movimiento_Pequeño>().enabled = true;
            Pausa.nPersonaje = 2;

        }


    }
    void LateUpdate()
    {
        transform.position = Target.position + sitioCamara;
    }
}
