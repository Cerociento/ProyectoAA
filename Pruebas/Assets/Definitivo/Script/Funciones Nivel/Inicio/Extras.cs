using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Extras : MonoBehaviour {

    [SerializeField]
    GameObject[] extras;
    [SerializeField]
    GameObject[] candados;
    [SerializeField]
    Sprite candadoAbierto;

    void Start()
    {
        Coleccionables();
    }

    void Coleccionables()
    {
        for (int i = 0; i < CargarGuardar.CColeccionable; i++)
        {
            candados[i].GetComponent<Image>().sprite = candadoAbierto;
        }
	}
}
