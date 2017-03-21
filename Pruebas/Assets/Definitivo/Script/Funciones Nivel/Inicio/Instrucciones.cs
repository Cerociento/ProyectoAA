using UnityEngine;
using System.Collections;

public class Instrucciones : MonoBehaviour {

     [SerializeField]
     GameObject[] Imagenes;

    [ContextMenu ("Pulsar")]
     public void Pulsar(int num)
     {
        foreach (GameObject item in Imagenes)
        {
            item.SetActive(false);
            Imagenes[num].SetActive(true);
        }

     }
}
