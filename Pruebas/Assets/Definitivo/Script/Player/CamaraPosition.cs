using UnityEngine;
using System.Collections;

public class CamaraPosition : MonoBehaviour {

    [SerializeField]
    Vector3 nuevoLugar;
    bool transitionP;
    bool transitionG;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pequeño"))
        {
            transitionP = true;
        }
        else if (other.CompareTag("Grande")|| other.CompareTag("Escondido"))
        {
            transitionG = true;
        }
    }

    void LateUpdate()
    {
        if (transitionP)
        {
            Camara.transicion = true;
            Camara._sitioCamara = nuevoLugar;
            Camara.transicion = false;
            transitionP = false;
        }

        if (transitionG)
        {
            Camara.transicion = true;
            Camara._sitioCamaraG = nuevoLugar;
            Camara.transicion = false;
            transitionG = false;
        }
    }
}
