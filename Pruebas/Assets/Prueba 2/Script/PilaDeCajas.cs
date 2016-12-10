using UnityEngine;
using System.Collections;

public class PilaDeCajas : MonoBehaviour
{
    [SerializeField]
    GameObject[] Caja;
    int activador;
    bool coger=true;

    void Update()
    {
        if (activador == Caja.Length)
        {
            Caja = new GameObject[0];
            Destroy(this.gameObject, 2);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Grande"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (coger)
                {
                    Transform sitioIntanciado = other.transform.GetChild(0).GetChild(3).GetChild(2);
                    if (activador < Caja.Length)
                    {                      
                        Instantiate(Caja[activador], sitioIntanciado.position, sitioIntanciado.rotation,sitioIntanciado);
                        activador++;
                    }                 
                        coger = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.E))
                coger = true;
        }
    }
}	
