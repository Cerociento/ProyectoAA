using UnityEngine;
using System.Collections;

public class Movimiento_Grande : MonoBehaviour 
{


    //Movimiento
    [SerializeField]
    float velocidad = 1f;
    float ZAxis = 0f;
    float YAxis;
    float LAxis;
  
    //Rotacion Camara
    [SerializeField]
    float velRotacion;   

    //Cajas 
    [SerializeField]
    GameObject caja;
    [SerializeField]
    public static bool soltar = false;
    bool escondite=false;
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
        soltar = false;
        caja = null;
    }

    void Update()
    {
        if(asignarCaja)
           caja = Caja.caja;
        #region MOVIMIENTO        
        if (!Laser.paraMover)
        {
            YAxis = Input.GetAxis("Horizontal");
            ZAxis = Input.GetAxis("Vertical");

            if (ZAxis > 0 && Input.GetKey(KeyCode.W) || ZAxis < 0 && Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * ZAxis);
                if (!sonido.isPlaying)
                {
                    sonido.Play();
                }
            }

            if (YAxis < 0 && Input.GetKey(KeyCode.A) || YAxis > 0 && Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * velRotacion * YAxis);
            }

			if (YAxis == 0 && ZAxis == 0 && LAxis==0)
            {
                sonido.Stop();
            }
        }

        LAxis = Input.GetAxis("Lateral");
		if (LAxis < 0 || LAxis > 0){
            transform.Translate(1f * velocidad * Time.deltaTime * LAxis, 0, 0);
			if(!sonido.isPlaying){
				sonido.Play();
			}
		}
#endregion

        if (Input.GetKeyDown(KeyCode.LeftControl)|| Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (caja)
            {     
                soltar = !soltar;
                if (!soltar)
                    Coger();
                else
                    Soltar();      
            }
            else
            {
                Debug.Log("Ninguna caja cerca");
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0))
            {
                asignarCaja = false;
                if (gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<SphereCollider>().enabled == true)
                {
                    caja = gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).gameObject;
                    gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<SphereCollider>().enabled = false;
                }
        }
            else
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
                    Soltar();
                    caja.GetComponent<Caja>().Choque();
                    caja = null;
                    asignarCaja = true;
                    gameObject.layer = 9;
                    gameObject.tag = "Escondido";
                    escondite = false;
                    soltar = true;
                    Escondido();
                }
            }
            else if (!caja.CompareTag("Caja Escondite"))
            {
                Debug.Log("Ninguna caja cerca");
            }
        }

		if(Input.GetKeyDown(KeyCode.R))
        {
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

    public void Coger()
    {
            asignarCaja = false;
            caja.transform.position = gameObject.transform.GetChild(0).GetChild(2).GetChild(2).position;
            caja.transform.parent = gameObject.transform.GetChild(0).GetChild(2).GetChild(2);
            caja.GetComponent<BoxCollider>().enabled = false;
            caja.GetComponent<SphereCollider>().enabled = false;
            caja.GetComponent<Rigidbody>().useGravity = false;
            caja.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Soltar()
    {
        if (caja)
        {
            asignarCaja = true;
            gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<SphereCollider>().enabled = true;
            gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<BoxCollider>().enabled = true;
            gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<Rigidbody>().useGravity = true;
            gameObject.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.GetChild(0).GetChild(2).GetChild(2).DetachChildren();
        }
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
