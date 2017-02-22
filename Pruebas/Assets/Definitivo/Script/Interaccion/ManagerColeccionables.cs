using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerColeccionables : MonoBehaviour {

    [SerializeField]
    GameObject ImageExtra;

    public static bool[] listaGuardar = new bool[12];


    public void Extra () {

        switch (Pausa.recogidos)
        {
            case 1:
                ImageExtra.SetActive(true);
                break;
            case 3:
                ImageExtra.SetActive(true);
                break;
            case 4:
                ImageExtra.SetActive(true);
                break;
            case 6:
                ImageExtra.SetActive(true);
                break;
            case 8:
                ImageExtra.SetActive(true);
                break;
            case 10:
                ImageExtra.SetActive(true);
                break;
            case 13:
                ImageExtra.SetActive(true);
                break;
        }
        StartCoroutine("ExtraDesbloqueado");
    }

    void Update()
    {

        if(Input.GetKey(KeyCode.G))
        {
            listaGuardar[0] = false;
        }
        else if(Input.GetKey(KeyCode.H))
            listaGuardar[0] = true;
    }

    IEnumerator ExtraDesbloqueado()
    {
        yield return new WaitForSeconds(2);
        if(ImageExtra.activeInHierarchy)
             ImageExtra.SetActive(false);
        GetComponent<CargarGuardar>().Guardar();

    }
}


