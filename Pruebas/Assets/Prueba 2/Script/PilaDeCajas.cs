using UnityEngine;
using System.Collections;

public class PilaDeCajas : MonoBehaviour
{
    [SerializeField]
    GameObject[] Caja;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Grande"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(Caja.Length);
              
                for (int i = Caja.Length-1; i >0; i--)
                {
                    Transform sitioIntanciado = other.transform.GetChild(0).GetChild(3).GetChild(2);
                    Instantiate(Caja[i], sitioIntanciado.position, sitioIntanciado.rotation, sitioIntanciado);                  
                }
            }
        }
}
	

}
