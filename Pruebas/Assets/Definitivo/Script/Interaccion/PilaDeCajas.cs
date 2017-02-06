using UnityEngine;
using System.Collections;

public class PilaDeCajas : MonoBehaviour
{
    [SerializeField]
    GameObject[] Caja;
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

        if (activador == Caja.Length)
            {
            if (cajasEscondite)
                activador = 0;
            else
            {
                Caja = new GameObject[0];
                Destroy(this.gameObject, 2);
            }
            }

        if (coger)
        {
            Movimiento_Grande.soltar = false;
            sonido.PlayOneShot(sonidoCaja);
            Transform sitioIntanciado = GameObject.Find("Grande").transform.GetChild(0).GetChild(2).GetChild(2);

            if (activador < Caja.Length)
            {
                if (cajasEscondite)
                {
                   managerPool.getBox();
                }
                else
                {
                   Instantiate(Caja[activador], sitioIntanciado.position, sitioIntanciado.rotation, sitioIntanciado);  
                   activador++;
                }
            }

            coger = false;
        }
        else if(GameObject.FindGameObjectWithTag("Caja Escondite") == null)
            GetComponent<SphereCollider>().enabled = true;
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
