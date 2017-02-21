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

    int ultimoColeccionable;
    List<int> lista;

    void Start()
    {
        Coleccionables();
        Debug.Log("Iniciado");
       
    }

    void Coleccionables()
    {

        for (int i = 0; i < CargarGuardar.CColeccionable; i++)
         {

             switch (CargarGuardar.CColeccionable)
             {
                case 2:
                case 1:
                     botonColor = candados[0].GetComponent<Button>().colors;
                     candados[0].GetComponent<Image>().sprite = candadoAbierto;
                     botonColor.highlightedColor = new Color32(77, 255, 77, 255);
                     botonColor.pressedColor = new Color32(0, 218, 0, 255);
                     candados[0].GetComponent<Button>().colors = botonColor;
                     ultimoColeccionable = 1;
                     break;

               
                case 3:
                     botonColor = candados[1].GetComponent<Button>().colors;
                     candados[1].GetComponent<Image>().sprite = candadoAbierto;
                     botonColor.highlightedColor = new Color32(77, 255, 77, 255);
                     botonColor.pressedColor = new Color32(0, 218, 0, 255);
                     candados[1].GetComponent<Button>().colors = botonColor;
                    ultimoColeccionable = 3;
                     goto case 1;
                case 5:
                case 4:
                     botonColor = candados[2].GetComponent<Button>().colors;
                     candados[2].GetComponent<Image>().sprite = candadoAbierto;
                     botonColor.highlightedColor = new Color32(77, 255, 77, 255);
                     botonColor.pressedColor = new Color32(0, 218, 0, 255);
                     candados[2].GetComponent<Button>().colors = botonColor;
                    ultimoColeccionable = 4;
                     goto case 3;
                case 7:
                case 6:
                     botonColor = candados[3].GetComponent<Button>().colors;
                     candados[3].GetComponent<Image>().sprite = candadoAbierto;
                     botonColor.highlightedColor = new Color32(77, 255, 77, 255);
                     botonColor.pressedColor = new Color32(0, 218, 0, 255);
                     candados[3].GetComponent<Button>().colors = botonColor;
                    ultimoColeccionable = 6;
                    goto case 4;
                case 9:
                case 8:
                     botonColor = candados[4].GetComponent<Button>().colors;
                     candados[4].GetComponent<Image>().sprite = candadoAbierto;
                     botonColor.highlightedColor = new Color32(77, 255, 77, 255);
                     botonColor.pressedColor = new Color32(0, 218, 0, 255);
                     candados[4].GetComponent<Button>().colors = botonColor;
                    ultimoColeccionable = 8;
                    goto case 6;
                case 11:
                case 10:
                     botonColor = candados[5].GetComponent<Button>().colors;
                     candados[5].GetComponent<Image>().sprite = candadoAbierto;
                     botonColor.highlightedColor = new Color32(77, 255, 77, 255);
                     botonColor.pressedColor = new Color32(0, 218, 0, 255);
                     candados[5].GetComponent<Button>().colors = botonColor;
                    ultimoColeccionable = 10;
                    goto case 8;
               
                case 12:
                     botonColor = candados[6].GetComponent<Button>().colors;
                     candados[6].GetComponent<Image>().sprite = candadoAbierto;
                     botonColor.highlightedColor = new Color32(77, 255, 77, 255);
                     botonColor.pressedColor = new Color32(0, 218, 0, 255);
                     candados[6].GetComponent<Button>().colors = botonColor;
                    ultimoColeccionable = 12;
                    goto case 10;     
             }
         }
    }
}
