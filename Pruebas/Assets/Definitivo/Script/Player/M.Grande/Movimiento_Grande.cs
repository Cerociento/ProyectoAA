using UnityEngine;
using System.Collections;

public class Movimiento_Grande : MonoBehaviour 
{
    //Movimiento
    [SerializeField]
    public float velocidad = 1f;
    public float moveSpeed = 5f;
    public float rotateSpeed = 15f;
    Vector2 input;
    Vector3 camForward;
    Vector3 lookingDirection;
    Transform CameraTransform;
    CharacterController controller;
    Vector3 moveDirection = Vector2.zero;
    Vector3 gravity = Vector3.zero;
    public static bool mantDireccion = true;

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
    public static bool _asignarCaja = true;

    //Animaciones
    [SerializeField]
    Animator anim;
    public static Animator _anim;

    //Checkpoint
    public static Vector3 checkpointGrande = new Vector3(0, 1.5f, 0);

	//Audio 13-01-2017
	[SerializeField]
	AudioSource sonido;

    [SerializeField]
    Caja[] hijo;

    void Start()
    {
        colorAlfa = transform.GetChild(1).GetChild(0).GetComponent<Renderer>().material.color;
        soltar = false;
        caja = null;
        _anim = anim;
        controller = transform.GetComponent<CharacterController>();
        CameraTransform = Camera.main.transform;
        lookingDirection = moveDirection;
    }

    void Update()
    {
        hijo = GetComponentsInChildren<Caja>();

        asignarCaja = _asignarCaja;
        if(asignarCaja)
           caja = Caja.caja;

        #region MOVIMIENTO 
        PJAngle();
        HorizontalMovement();
        Jump();
        moveDirection *= velocidad;
        controller.Move(moveDirection * Time.deltaTime);
        #endregion


        #region MOVIMIENTO        
        /* if (!Laser.paraMover)
         {
             YAxis = Input.GetAxis("Horizontal");
             ZAxis = Input.GetAxis("Vertical");

             if (ZAxis > 0 || ZAxis < 0)
             {
                 transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * ZAxis);
                 anim.SetFloat("Andar", ZAxis);
                 if (!sonido.isPlaying)
                 {
                     sonido.Play();
                 }
             }
             else
             {
                 anim.SetFloat("Andar", 0);
             }

             if (YAxis < 0 || YAxis > 0)
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
         }*/
        #endregion

        if (Input.GetKeyDown(KeyCode.LeftControl)|| Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (caja)
            {
                soltar = !soltar;

                if (!soltar)
                {
                    Coger();
                }
                else
                {
                    Soltar();
                }
            }
            else if (caja == null)
                if (hijo==null)
                {
                    return;
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
            }

		if(Input.GetKeyDown(KeyCode.R))
        {
			transform.position = checkpointGrande;
			Pausa.vecesVisto++;
		}
	}

    void HorizontalMovement()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        camForward = Vector3.Scale(CameraTransform.forward, new Vector3(1, 0, 1));
        moveDirection = input.x * CameraTransform.right + input.y * camForward;
        anim.SetFloat("Andar", input.sqrMagnitude);

        if (!sonido.isPlaying)
        {
            sonido.Play();
        }

        if (input.sqrMagnitude > 0f)
        {
            lookingDirection = moveDirection;
        }

        moveDirection = moveDirection.normalized;
        moveDirection.x *= moveSpeed;
        moveDirection.z *= moveSpeed;
    }

    void PJAngle()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(lookingDirection), Time.deltaTime * rotateSpeed);
    }

    void Jump()
    {
        if (!controller.isGrounded)
        {
            gravity += Physics.gravity * Time.deltaTime;
        }
        else
        {
            gravity = Vector3.zero;
        }
        moveDirection += gravity;
    }

    void Escondido()
    {
        colorAlfa.a = 0.3f;
        anim.SetBool("Esconder", true);
        gameObject.transform.GetChild(1).GetChild(0).GetComponent<Renderer>().material.color = colorAlfa;
        StartCoroutine("Esconder", 10);
    }

    public void Coger()
    {       
            caja.transform.position = gameObject.transform.GetChild(0).GetChild(1).GetChild(0).position;
            caja.transform.parent = gameObject.transform.GetChild(0).GetChild(1).GetChild(0);
            caja.GetComponent<BoxCollider>().enabled = false;
            caja.GetComponent<SphereCollider>().enabled = false;
            caja.GetComponent<Rigidbody>().useGravity = false;
            caja.GetComponent<Rigidbody>().isKinematic = true;
            anim.SetBool("Coger", true);
            anim.SetBool("Esconder", false);
           _asignarCaja = false;
    }

    public void Soltar()
    {
        if (!caja.CompareTag("Caja Escondite"))
        {
            _asignarCaja = true;
           foreach (Caja cajaH in hijo)
            {
                cajaH.GetComponent<SphereCollider>().enabled = true;
                cajaH.GetComponent<BoxCollider>().enabled = true;
                cajaH.GetComponent<Rigidbody>().useGravity = true;
                cajaH.GetComponent<Rigidbody>().isKinematic = false;
            }
            if (hijo.Length > 0)
                gameObject.transform.GetChild(0).GetChild(1).GetChild(0).DetachChildren();
            anim.SetBool("Coger", false);
            Caja.caja = null;
        }
        else
        {
            _asignarCaja = true;
            gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<SphereCollider>().enabled = true;
            gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = true;
            gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Rigidbody>().useGravity = true;
            gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            caja.transform.parent = GameObject.Find("Manager").transform;
            anim.SetBool("Coger", false);
            Caja.caja = null;
        }
    }

    IEnumerator Esconder(int time)
    {
        yield return new WaitForSeconds(time);
        colorAlfa.a = 1f;
        gameObject.transform.GetChild(1).GetChild(0).GetComponent<Renderer>().material.color = colorAlfa;
        gameObject.tag = "Grande";
        gameObject.layer = 11;
        anim.SetBool("Esconder", false);
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
