using UnityEngine;
using System.Collections;

public class Final : MonoBehaviour 
{
    [SerializeField]
    GameObject barreraFinalPequeño;
    [SerializeField]
    GameObject barreraFinalGrande;

    [SerializeField]
    GameObject sueloPequeño;
    [SerializeField]
    GameObject sueloGrande;
   
    bool subePequeño;
    bool subeGrande;
    
    void Update()
    {
        if (subePequeño && subeGrande)
        {
            sueloPequeño.transform.Translate(Vector3.up * Time.deltaTime);
            sueloGrande.transform.Translate(Vector3.up * Time.deltaTime);
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pequeño"))
        {
            if (!subePequeño)
            {
                barreraFinalPequeño.SetActive(true);
                subePequeño = true;
                //Destroy(gameObject);
                GameObject.FindWithTag("Grande").transform.Translate(Vector3.up);
               
                
            }

        }

        if (other.CompareTag("Grande"))
        {
            if (!subeGrande)
            {
                barreraFinalGrande.SetActive(true);
                subeGrande = true;
                //Destroy(gameObject);
                GameObject.FindWithTag("Pequeño").transform.Translate(Vector3.up);
            }
        }
    }

	

}
