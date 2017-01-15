using UnityEngine;
using System.Collections;

public class RayoParaTransparencia : MonoBehaviour {
    // [SerializeField] 
    // Transform TargetCam;

      [SerializeField]
      Transform Target1;
      [SerializeField]
      Transform Target2;

      public RaycastHit rayo = new RaycastHit();


      void Update()
      {
        //  TargetCam = Camara.Target;

         /* if (Physics.Linecast(transform.position, TargetCam.position, out rayo))
          {
              Debug.DrawLine(transform.position, TargetCam.position, Color.green);
          }
          if (Input.GetKeyDown(KeyCode.Alpha1))
          {
              TargetCam = Target1;
          }
          if (Input.GetKeyDown(KeyCode.Alpha2))
          {
              TargetCam = Target2;        
          }*/
      }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Background"))
        {
            other.GetComponent<ParedPersiana>().persiana = true;          
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Background"))
        {
            other.GetComponent<ParedPersiana>().persiana = false;
        }
    }
}
