using UnityEngine;
using System.Collections;

public class PilaDeCajas : MonoBehaviour
{
    [SerializeField]
    GameObject[] cajaList;
    int activador;
    [SerializeField]
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

    ManagerPool managerPool;


    void Start()
    {
        managerPool = GameObject.Find("Manager").GetComponent<ManagerPool>();
    }

    void Update()
    {

        if (instrucciones)
		texto.transform.LookAt(Camera.main.transform);
        else
        {
            texto = null;
        }

        if (activador == cajaList.Length)
            {
            if (cajasEscondite)
                activador = 0;
            else
            {
                cajaList = new GameObject[0];
                Destroy(this.gameObject, 2);
            }
            }

        if (coger)
        {
            Movimiento_Grande.soltar = false;
            sonido.PlayOneShot(sonidoCaja);
            Transform sitioIntanciado = GameObject.Find("Grande").transform.GetChild(0).GetChild(1).GetChild(0);
            Movimiento_Grande._anim.SetBool("Coger", true);
            Movimiento_Grande._anim.SetBool("Esconder", false);
            if (activador < cajaList.Length)
            {
                if (cajasEscondite)
                {
                   managerPool.getBox();
                }
                else
                {
                   Instantiate(cajaList[activador], sitioIntanciado.position, sitioIntanciado.rotation, sitioIntanciado);  
                   activador++;
                }
            }
           else if (Caja.caja== null)
                Movimiento_Grande.soltar=true;

            coger = false;
        }
    }   
    

    void OnTriggerStay(Collider other)
  {
        if (other.CompareTag("Grande") && Input.GetKeyDown(KeyCode.LeftControl) || other.CompareTag("Grande") && Input.GetKeyUp(KeyCode.Mouse0) || other.CompareTag("Escondido") && Input.GetKeyDown(KeyCode.LeftControl) || other.CompareTag("Escondido") && Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (other.transform.GetComponent<Movimiento_Grande>().enabled)
            {
                coger = true;
                if(instrucciones)
                   texto.SetActive(false);
            }
        }
 }   
}	
