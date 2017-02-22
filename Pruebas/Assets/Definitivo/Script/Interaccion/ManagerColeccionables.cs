using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerColeccionables : MonoBehaviour {

    [System.Serializable]
    public class Colecc
    {
        public GameObject Coleccionable;
        public bool recogida=true;

        public Colecc(GameObject coleccionable, bool recogido)
        {
            Coleccionable = coleccionable;
            recogido = true;
        }

    }

    [SerializeField]
    GameObject ImageExtra;

    [SerializeField]
    List<Colecc> lista;

    [SerializeField]
   public static Colecc coleccion= new Colecc(null,true);
    [SerializeField]
     Colecc coleccion1 = new Colecc(null, true);

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
            case 12:
                ImageExtra.SetActive(true);
                break;
        }
        StartCoroutine("ExtraDesbloqueado");
    }

    void Update()
    {
        coleccion1 = coleccion;
    }

    IEnumerator ExtraDesbloqueado()
    {
        yield return new WaitForSeconds(2);
        if(ImageExtra.activeInHierarchy)
             ImageExtra.SetActive(false);
        GetComponent<CargarGuardar>().Guardar();

    }
}


