using UnityEngine;
using System.Collections;

public class BotonParaPuertas : MonoBehaviour {

    [SerializeField]
    GameObject[] abrePuerta;

    void OnTriggerStay(Collider hit)
    {
        for (int i = 0; i < abrePuerta.Length; i++)
            if (hit.transform.CompareTag("Pequeño"))
        {
            Debug.Log("DENTRO");
            if (Input.GetKeyDown(KeyCode.E))
            {          
                    Debug.Log(i);
                    Destroy(abrePuerta[i]);
                    transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}
