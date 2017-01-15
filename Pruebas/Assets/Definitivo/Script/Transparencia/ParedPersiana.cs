using UnityEngine;
using System.Collections;

public class ParedPersiana : MonoBehaviour 
{

    public bool persiana;
    [SerializeField]
    float velocidad;

    void LateUpdate()
    {
        if (persiana)
        {
            if (transform.GetChild(0).localPosition.y >= -4f)
                transform.GetChild(0).Translate(0, -1 * velocidad * Time.deltaTime, 0);           
        }
        else
        {
            if (transform.GetChild(0).localPosition.y <= 0f)
                transform.GetChild(0).Translate(0, 1 * velocidad * Time.deltaTime, 0);
            if (transform.GetChild(0).localPosition.y > 0f)
            {
                transform.GetChild(0).localPosition = Vector3.zero;
            }
        }

        
    }
}
