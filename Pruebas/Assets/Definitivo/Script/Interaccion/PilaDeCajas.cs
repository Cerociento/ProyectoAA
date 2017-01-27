using UnityEngine;
using System.Collections;

public class PilaDeCajas : MonoBehaviour
{
    [SerializeField]
    GameObject[] Caja;
    int activador;
    bool coger = false;
	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioClip sonidoCaja;
    [SerializeField]
    GameObject texto;
    [SerializeField]
    bool instrucciones;
    [SerializeField]
    bool cajasEscondite;

    void Update()
    {
        if (instrucciones)
        {
            texto.transform.LookAt(Camera.main.transform);
        }
        else
        {
            texto = null;
        }

        if (activador == Caja.Length)
            {
            if (cajasEscondite)
                activador = 0;
            else
            {
                Caja = new GameObject[0];
                Destroy(this.gameObject, 2);
                Destroy(texto, 1);
            }
            }

        if (coger)
        {
            Movimiento_Grande.soltar = false;
            sonido.PlayOneShot(sonidoCaja);
            Transform sitioIntanciado = GameObject.Find("Grande").transform.GetChild(0).GetChild(2).GetChild(2);
            if (activador < Caja.Length)
            {
                Instantiate(Caja[activador], sitioIntanciado.position, sitioIntanciado.rotation, sitioIntanciado);
                activador++;
            }

            coger = false;
        }         
        }   
    

    void OnTriggerStay(Collider other)
  {
    if (other.CompareTag("Grande") && Input.GetKeyDown(KeyCode.LeftControl) || other.CompareTag("Grande") && Input.GetKeyUp(KeyCode.Mouse0)|| other.CompareTag("Escondido") && Input.GetKeyDown(KeyCode.LeftControl) || other.CompareTag("Escondido") && Input.GetKeyUp(KeyCode.Mouse0))
    {
            coger = true;
            texto.SetActive(false);
    }
 }   
}	
