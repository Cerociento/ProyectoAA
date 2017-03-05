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
    bool activo;
    [SerializeField]
    bool cajasEscondite;

    ManagerPool managerPool;


    void Start()
    {
        managerPool = GameObject.Find("Manager").GetComponent<ManagerPool>();
    }

    void Update()
    {

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
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.Mouse0))
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
                else if (Caja.caja == null)
                    Movimiento_Grande.soltar = true;

                coger = false;
            }
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Grande") || other.CompareTag("Escondido"))
        {
            if (other.transform.GetComponent<Movimiento_Grande>().enabled)
            {
                if(Caja.caja == null)
                {
                    coger = true;
                }
            }
        }

        if (other.CompareTag("Caja") && Caja.caja == null)
            other.transform.Translate(Vector3.forward);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grande") || other.CompareTag("Escondido"))
        {
            if (other.transform.GetComponent<Movimiento_Grande>().enabled)
            {
                    coger = false;
            }
        }
    }


}	
