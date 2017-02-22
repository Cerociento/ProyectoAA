using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Extras : MonoBehaviour {

    [SerializeField]
    GameObject[] extras;
    [SerializeField]
    GameObject[] candados;
    [SerializeField]
    Sprite candadoAbierto;
    ColorBlock botonColor;
    [SerializeField]
    int ultimoColeccionable;
    [SerializeField]
    List<int> listaCandados;

    [SerializeField]
    List<int> listaActivas;

    [SerializeField]
    Button botonDerecha;
    [SerializeField]
    Button botonIzquierda;

    CargarGuardar guardar;
    int valorImagenes;

    void Start()
    {
        Coleccionables();
    }

    void Coleccionables()
    {
             switch (CargarGuardar.CColeccionable)
             {
                case 2:
                case 1:
                    listaCandados.Add(0);
                    Candados();
                    break;

                case 3:
                        listaCandados.Add(1);
                    Candados();
                    goto case 1;
                case 5:
                case 4:
                        listaCandados.Add(2);
                    Candados();
                    goto case 3;
                case 7:
                case 6:
                        listaCandados.Add(3);
                    Candados();
                    goto case 4;
                case 9:
                case 8:
                        listaCandados.Add(4);
                    Candados();
                    goto case 6;
                case 11:
                case 12:
                case 10:
                        listaCandados.Add(5);
                    Candados();
                    goto case 8;
                case 13:
                        listaCandados.Add(6);
                    Candados();
                    goto case 10;
             }
    }

    void Candados()
    {
       foreach(int num in listaCandados)
        {
            botonColor = candados[num].GetComponent<Button>().colors;
            candados[num].GetComponent<Image>().sprite = candadoAbierto;
            botonColor.highlightedColor = new Color32(77, 255, 77, 255);
            botonColor.pressedColor = new Color32(0, 218, 0, 255);
            candados[num].GetComponent<Button>().colors = botonColor;
            candados[num].GetComponent<Button>().interactable = true;
        }
    }

    public void ImagenesActivas(int activas)
    {
        listaActivas.Add(activas);
        extras[listaActivas[0]].SetActive(true);
        if (listaActivas.Count <= 1)
        {
            botonDerecha.interactable = false;
            botonIzquierda.interactable = false;
        }
        else
        {
            botonDerecha.interactable = true;
        }
    }

    public void DesactivarImagenes(bool limpieza)
    {
        foreach (GameObject obj in extras)
        {
            obj.SetActive(false);
            if (limpieza)
            {
                listaActivas.Clear();
                valorImagenes = 0;
            }
        }
    }

    public void Botones (bool direccion)
    {
        DesactivarImagenes(false);

        if (direccion)
        {
            botonIzquierda.interactable = true;
            if (valorImagenes != listaActivas.Count-1)
                ++valorImagenes;

            if (valorImagenes == listaActivas.Count-1)
                botonDerecha.interactable = false;
        }
        else
        {
            botonDerecha.interactable = true;
            if (valorImagenes > 0)
                valorImagenes--;
            
            if(valorImagenes==0)
                botonIzquierda.interactable = false;
        }

        extras[listaActivas[valorImagenes]].SetActive(true);


    }

    void Update()
    {

#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Space))
        {
            guardar = GameObject.Find("Manager").GetComponent<CargarGuardar>();
            Pausa.recogidos = ultimoColeccionable;
            guardar.Guardar();
        }
#endif
    }
}
