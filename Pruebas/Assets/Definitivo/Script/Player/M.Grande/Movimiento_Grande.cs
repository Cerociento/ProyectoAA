﻿using UnityEngine;
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
    //float rango = 1;

    //Rotacion Personaje
    //float maxAnguloHorizontal = 180.0f;
    //Quaternion rotacionBase;
    //Quaternion rotacionDeseada;


    //Rotacion Camara
    [SerializeField]
    float velCamara;
    float AxisCam = 0;
   

    //Cajas 
    [SerializeField]
    GameObject caja;
    [SerializeField]
    public static bool soltar = false;
    bool escondite=false;
   // public static Vector3 posicion;
    Color colorAlfa;
    [SerializeField]
    bool asignarCaja;

    //Checkpoint
    public static Vector3 checkpointGrande = new Vector3(0, 1.5f, 0);

	//Audio 13-01-2017
	[SerializeField]
	AudioSource sonido;

    void Start()
    {
        colorAlfa = transform.GetChild(0).GetComponent<Renderer>().material.color;
       // posicion = new Vector3(transform.position.x, transform.position.y, transform.position.z+5);
       // CamCamera.LookAt(posicion);
        soltar = false;
       // rotacionBase = transform.rotation;
      //  rotacionDeseada = Quaternion.identity;
        caja = null;
    }

    void Update()
    {
        if(asignarCaja)
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
				if(!sonido.isPlaying){
					sonido.Play();
				}
             }
             else if (ZAxis < 0 && Input.GetKey(KeyCode.S))
             {

                 transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * -ZAxis);
                 transform.eulerAngles = new Vector3(0, CamCamera.transform.eulerAngles.y - 180, 0f);
				if(!sonido.isPlaying){
					sonido.Play();
				}
             }

             if (YAxis < 0 && Input.GetKey(KeyCode.A))
              {
                  transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * -YAxis);
                  transform.eulerAngles = new Vector3(0, HorizontalCamara.transform.eulerAngles.y - 180, 0f);
				if(!sonido.isPlaying){
					sonido.Play();
				}
              }
              else if (YAxis > 0 && Input.GetKey(KeyCode.D))
              {
                  transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * YAxis);
                  transform.eulerAngles = new Vector3(0, HorizontalCamara.transform.eulerAngles.y, 0f);
				if(!sonido.isPlaying){
					sonido.Play();
				}
              }
			if(YAxis==0 && ZAxis==0){
				sonido.Stop();
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
           // HorizontalCamara.localPosition = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.E)|| Input.GetKeyUp(KeyCode.Mouse2))
        {
            if (caja)
            {     
                soltar = !soltar;                
                if (soltar)
                {
                    asignarCaja = true;
                    gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<SphereCollider>().enabled = true;
                    gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<BoxCollider>().enabled = true;
                    gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<Rigidbody>().useGravity = true;
                    gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                    gameObject.transform.GetChild(0).GetChild(2).GetChild(2).DetachChildren();
                    
                }
                else
                {
                    asignarCaja = false;
                    caja.transform.position = gameObject.transform.GetChild(0).GetChild(2).GetChild(2).position;
                    caja.transform.parent = gameObject.transform.GetChild(0).GetChild(2).GetChild(2);
                    caja.GetComponent<BoxCollider>().enabled = false;
                    caja.GetComponent<SphereCollider>().enabled = false;
                    caja.GetComponent<Rigidbody>().useGravity = false;
                    caja.GetComponent<Rigidbody>().isKinematic = true;
                   
                }             
            }
            else
            {
                Debug.Log("Ninguna caja cerca");
            }
        }

        if (Input.GetKeyUp(KeyCode.E)|| Input.GetKeyUp(KeyCode.Mouse2))
        {
            if (gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0))
            {
                asignarCaja = false;
                if (gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<SphereCollider>().enabled == true)
                {
                    
                    caja = gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).gameObject;
                    gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<SphereCollider>().enabled = false;
                }
        } else
        {
            Debug.Log("No hijo");
        }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (caja.CompareTag("Caja Escondite"))
            {
                escondite = !escondite;
                if (escondite)
                {
                    caja.SetActive(false);
                    Destroy(caja);
                    asignarCaja = true;
                    gameObject.layer = 9;
                    gameObject.tag = "Escondido";
                    escondite = false;
                    soltar = true;
                    Escondido();
                }
            }
            else
            {
                Debug.Log("Ninguna caja cerca");
            }
        }

		if(Input.GetKeyDown(KeyCode.R)){
			transform.position = checkpointGrande;
			Pausa.vecesVisto++;
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
            StartCoroutine("Guarda");
        }
    }

    IEnumerator Guarda()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("Manager").GetComponent<CargarGuardar>().Guardar();
    }
}
