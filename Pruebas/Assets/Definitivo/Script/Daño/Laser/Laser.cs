using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    LineRenderer lr;
    RaycastHit hit;

    [SerializeField]
    float velocidad;
    float YAxis = 0f;
    [SerializeField]
    int num = 0;
    
    public static bool paraMover;

    void Start()
    {
        paraMover = false;
        num = 0;
        lr = GetComponent<LineRenderer>();
         transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
    }

    void Update()
      {
          if(Physics.Raycast(transform.position,transform.forward,out hit))
          {
              if (hit.collider)
              {
                  lr.SetPosition(0, Vector3.zero);
                  lr.SetPosition(1, new Vector3(0, 0, hit.distance));
              }

              if (hit.collider.CompareTag("Grande"))
              {
                hit.transform.position = Movimiento_Grande.checkpointGrande;
                Pausa.vecesVisto++;
            }

            if (hit.collider.CompareTag("Pequeño"))
              {
                hit.transform.position = Movimiento_Pequeño.checkpointPequeño;
                Pausa.vecesVisto++;
            }

            if (num == 0)
                { 
                if (hit.collider.CompareTag("Llave"))
                {
                    transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
                    Salida_Laser.numLlaves++;
                    num++;
                }
            }
        
            if(hit.collider.tag!=("Llave"))
            {
                if (num > 0)
                {
                    transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                    Salida_Laser.numLlaves--;
                    num = 0;
                }
            }
        }
          else
          {
              lr.SetPosition(1, new Vector3(0, 0, 200));
          }

     // drawLaser(transform.position, 3);
  }
  void OnTriggerStay(Collider hit)
    {
        YAxis = Input.GetAxis("Horizontal");
        if (hit.gameObject.CompareTag("Grande"))
      {
            if (Input.GetKeyDown(KeyCode.E))
            {
                paraMover = !paraMover;
            }
            if (paraMover && YAxis > 0 && Input.GetKey(KeyCode.D)||paraMover && YAxis < 0 && Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Rotate(0, 1f * velocidad * YAxis * Time.deltaTime, 0);
            }    
      }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Grande"))
            paraMover = false;
    }

 /*void drawLaser(Vector3 startPoint,int n)
  {
      RaycastHit hit;
     Vector3 rayDir = transform.TransformDirection(Vector3.forward);

      for (var i = 0; i < n; i++)
      {
          if (Physics.Raycast(startPoint, rayDir,out hit, 1000))
          {
            if (hit.collider)
            {
                Debug.DrawLine(startPoint, hit.point);
                rayDir = Vector3.Reflect((hit.point - startPoint).normalized, hit.normal);
                startPoint = hit.point;
            }

           }
      }
  }*/
}