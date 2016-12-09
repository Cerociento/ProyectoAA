using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
      LineRenderer lr;
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
       RaycastHit hit;

          if(Physics.Raycast(transform.position,transform.forward,out hit))
          {
              if (hit.collider)
              {
                  lr.SetPosition(1, new Vector3(0, 0, hit.distance));
              }
              if (hit.collider.CompareTag("Player"))
              {
                  Debug.Log("Muerto");
              }
            if (num == 0)
            {
                if (hit.collider.CompareTag("Llave"))
                {
                    transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
                    Salida.numLlaves++;
                    num++;
                }
            }
        
            if(hit.collider.tag!=("Llave"))
            {
                if (num > 0)
                {
                    transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                    Salida.numLlaves--;
                    num = 0;
                }
            }
        }
          else
          {
              lr.SetPosition(1, new Vector3(0, 0, 500));
          }

     // drawLaser(transform.position, 3);
  }
  void OnTriggerStay(Collider hit)
    {
        YAxis = Input.GetAxis("Horizontal");
        if (hit.gameObject.CompareTag("Player"))/* && Input.GetKey(KeyCode.E)&& YAxis > 0 && Input.GetKey(KeyCode.D) || hit.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E)&& YAxis < 0 && Input.GetKey(KeyCode.A))*/
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