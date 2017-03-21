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
        if (Physics.Raycast(transform.position,transform.forward,out hit))
          {
              if (hit.collider)
              {
                  lr.SetPosition(0, Vector3.zero);
                  lr.SetPosition(1, new Vector3(0, 0, hit.distance));
              }

              if (hit.collider.CompareTag("Grande"))
              {
                Manager.muertoGrande = true;
                //Pausa.vecesVisto++;
            }

            if (hit.collider.CompareTag("Pequeño"))
              {
                Manager.muertoPequeño = true;
               // Pausa.vecesVisto++;
            }
        }
          else
          {
              lr.SetPosition(1, new Vector3(0, 0, 200));
          }
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
}