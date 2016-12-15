using UnityEngine;
using System.Collections;

public class BotonParaPuertas : MonoBehaviour {

    [SerializeField]
    GameObject[] abrePuerta;
    bool activar = false;
    void Update()
    {
        for (int i = 0; i < abrePuerta.Length; i++)  
            if(activar)         
           if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log(i);
                    Destroy(abrePuerta[i]);
                    transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
                //activar = false;
                }
            

    }
    void OnTriggerEnter(Collider hit)
    {
    if (hit.transform.CompareTag("Pequeño"))
    {
            activar = true;
    }
    }


    void OnTriggerExit(Collider hit)
    {
        if (hit.transform.CompareTag("Pequeño"))
        {
            activar = true;
        }
    }
}
