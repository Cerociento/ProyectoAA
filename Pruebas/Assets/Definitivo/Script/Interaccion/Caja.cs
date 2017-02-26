using UnityEngine;
using System.Collections;

public class Caja : MonoBehaviour 
{
    public static GameObject caja;

    void Start()
    {
        caja = gameObject;
        StartCoroutine("DesColl");
    }

    void Update()
    {
        if (caja != gameObject)
        {
            GetComponent<SphereCollider>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Grande") || other.CompareTag("Escondido"))
        {
            if (Movimiento_Grande._asignarCaja)
            {
                caja = gameObject;
                other.GetComponent<Rigidbody>().Sleep();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grande") || other.CompareTag("Escondido"))
        {
            caja = null;
        }         
    }

    void OnCollisionStay()
    {
        if(gameObject.CompareTag("Caja Escondite"))
        {
            Choque();
        }
    }

    public void Choque()
    {
        caja = null;
        GetComponent<SphereCollider>().enabled = true;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        gameObject.SetActive(false);
    }

    IEnumerator DesColl()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<SphereCollider>().enabled = false;
    }

}
