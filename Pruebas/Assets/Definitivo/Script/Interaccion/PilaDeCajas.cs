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

    void Update()
    {
        if (activador == Caja.Length)
        {
            Caja = new GameObject[0];
            Destroy(texto, 1);
            Destroy(this.gameObject, 2);
            
        }

        if (coger)
        {
            Movimiento_Grande.soltar = false;
            sonido.PlayOneShot(sonidoCaja);
            Transform sitioIntanciado = GameObject.FindWithTag("Grande").transform.GetChild(0).GetChild(2).GetChild(2);
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
    if (other.CompareTag("Grande") && Input.GetKeyDown(KeyCode.E)|| other.CompareTag("Grande") && Input.GetKeyUp(KeyCode.Mouse2))
    {
            coger = true;
            texto.SetActive(false);
    }
 }   
}	
