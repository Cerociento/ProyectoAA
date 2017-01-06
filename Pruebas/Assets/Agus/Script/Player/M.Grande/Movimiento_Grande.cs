using UnityEngine;
using System.Collections;

public class Movimiento_Grande : MonoBehaviour 
{
    //Movimiento
    [SerializeField]
    float velocidad = 1f;
    float ZAxis = 0f;
    float YAxis;
    [SerializeField]
    Transform HorizontalCamara;
    [SerializeField]
    Transform CamCamera;
    float rango = 1;

    //Rotacion Personaje
    float maxAnguloHorizontal = 180.0f;
    Quaternion rotacionBase;
    Quaternion rotacionDeseada;


    //Rotacion Camara
    [SerializeField]
    float velCamara;
    float AxisCam = 0;
   

    //Esconderte 
    [SerializeField]
    GameObject caja;
    bool soltar=true;
    bool escondite=false;
   public static Vector3 posicion;
    Color colorAlfa;

    //Checkpoint
    public static Vector3 checkpointGrande = new Vector3(0, 1.5f, 0);

    void Start()
    {
        colorAlfa = transform.GetChild(0).GetComponent<Renderer>().material.color;
        posicion = new Vector3(transform.position.x, transform.position.y, transform.position.z+5);
        CamCamera.LookAt(posicion);

        rotacionBase = transform.rotation;
        rotacionDeseada = Quaternion.identity;
    }

    void Update()
    {
        caja = Caja.caja;
        
        if (!Laser.paraMover)
        {
            
            YAxis = Input.GetAxis("Horizontal");
            ZAxis = Input.GetAxis("Vertical");

            /*if (ZAxis > 0 && Input.GetKey(KeyCode.W)|| ZAxis < 0 && Input.GetKey(KeyCode.S))
            {              
                transform.Rotate(new Vector3(0, 1 * ZAxis, 0));

                if(ZAxis < 0 && transform.eulerAngles.y<=180 && transform.eulerAngles.y>=0)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);             
                    transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * -ZAxis);
                }

                if (ZAxis > 0 && transform.eulerAngles.y >= 0 && transform.eulerAngles.y <= 180)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * ZAxis);
                }
            }

            if (YAxis > 0 && Input.GetKey(KeyCode.D) || YAxis < 0 && Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, 1 * YAxis, 0));

                if (YAxis < 0 && transform.eulerAngles.y <= 270 && transform.eulerAngles.y >= 90)
                {
                    transform.eulerAngles = new Vector3(0, -90, 0);
                    transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * -YAxis);
                }

                if (YAxis > 0 && transform.eulerAngles.y >= 90 && transform.eulerAngles.y <= 270)
                {
                    transform.eulerAngles = new Vector3(0, 90, 0);
                    transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * YAxis);
                }
            }*/

             if (ZAxis > 0 && Input.GetKey(KeyCode.W))
             {
                 transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * ZAxis);
                 transform.eulerAngles = new Vector3(0, CamCamera.transform.eulerAngles.y, 0f);
             }
             else if (ZAxis < 0 && Input.GetKey(KeyCode.S))
             {

                 transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * -ZAxis);
                 transform.eulerAngles = new Vector3(0, CamCamera.transform.eulerAngles.y - 180, 0f);
             }

             if (YAxis < 0 && Input.GetKey(KeyCode.A))
              {
                  transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * -YAxis);
                  transform.eulerAngles = new Vector3(0, HorizontalCamara.transform.eulerAngles.y - 180, 0f);
              }
              else if (YAxis > 0 && Input.GetKey(KeyCode.D))
              {
                  transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * YAxis);
                  transform.eulerAngles = new Vector3(0, HorizontalCamara.transform.eulerAngles.y, 0f);
              }

            //exper

            /*  rotacionDeseada = Quaternion.Euler(0, Input.GetAxis("Horizontal") * 20, 0);

              float anguloDeseado = Quaternion.Angle(rotacionBase, transform.rotation * rotacionDeseada);

              if (YAxis < 0 && Input.GetKey(KeyCode.A)|| YAxis > 0 && Input.GetKey(KeyCode.D))
              {
                  if (anguloDeseado > maxAnguloHorizontal)
                  {
                      transform.rotation = Quaternion.RotateTowards(transform.rotation * rotacionDeseada, rotacionBase, anguloDeseado - maxAnguloHorizontal);
                      transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime);
                  }
                  else
                  {
                      transform.rotation = Quaternion.Slerp(transform.rotation,transform.rotation * rotacionDeseada, 0.25f);                   
                  }



              }*/

        }

        AxisCam = Input.GetAxis("Rotacion");
        if (AxisCam < 0 || AxisCam > 0)
        {
            HorizontalCamara.RotateAround(transform.position, Vector3.up * AxisCam,velCamara );
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (caja.CompareTag("Caja")|| caja.CompareTag("Caja Grande") || caja.CompareTag("Caja Escondite"))
            {
                soltar = !soltar;
                if (soltar)
                {
                    gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<BoxCollider>().enabled = true;
                    gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<Rigidbody>().useGravity = true;
                    gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                    gameObject.transform.GetChild(0).GetChild(2).GetChild(2).DetachChildren();
                }else
                {
                    caja.transform.position = gameObject.transform.GetChild(0).GetChild(2).GetChild(2).position;
                    caja.transform.parent = gameObject.transform.GetChild(0).GetChild(2).GetChild(2);
                    caja.GetComponent<BoxCollider>().enabled = false;           
                    caja.GetComponent<Rigidbody>().useGravity = false;
                    caja.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (caja.CompareTag("Caja Escondite"))
            {
                escondite = !escondite;
                if (escondite)
                {
                    Destroy(caja);
                    gameObject.layer = 9;
                    gameObject.tag = "Escondido";
                    Escondido();
                }
            }
        }
    }

    void Escondido()
    {

        colorAlfa.a = 0.1f;
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = colorAlfa;
        StartCoroutine("Esconder", 10);
    }

    IEnumerator Esconder(int time)
    {
        yield return new WaitForSeconds(time);
        colorAlfa.a = 1f;
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = colorAlfa;
        gameObject.tag = "Grande";
        gameObject.layer = 11;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            checkpointGrande = other.transform.position;
        }
    }
}
