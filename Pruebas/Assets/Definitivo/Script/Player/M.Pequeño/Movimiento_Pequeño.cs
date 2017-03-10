using UnityEngine;
using System.Collections;

public class Movimiento_Pequeño : MonoBehaviour 
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

    //Rotacion Camara
    [SerializeField]
    float velRotacion;

    //Salto
    [SerializeField]
    float fSalto;
    bool salto;

    //Checpoint
    public static Vector3 checkpointPequeño= new Vector3 (0,1.5f,0);

	//Audio
	[SerializeField]
	AudioSource sonido;
	[SerializeField]
	AudioSource sonidoBis;
	[SerializeField]
	AudioClip sonidoSalto;

    //Animaciones
    [SerializeField]
    Animator anim;
    public static Animator _anim;

    void Start()
    {
        _anim = anim;
        controller = transform.GetComponent<CharacterController>();
        CameraTransform = Camera.main.transform;
        lookingDirection = moveDirection;
    }

    void Update()
    {
        #region MOVIMIENTO 
        PJAngle();
        HorizontalMovement();
        Jump();
        moveDirection *= velocidad;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetButton("Jump") && controller.isGrounded)
        {
            salto = true;
        }
        #endregion

        #region MOVIMIENTO OBSOLETO  
        /* YAxis = Input.GetAxis("Horizontal");
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
              //transform.Rotate(Vector3.up * velRotacion * YAxis);
             transform.Translate(1f * velocidad * Time.deltaTime * YAxis,0,0);

         }

         if (YAxis == 0 && ZAxis == 0 && LAxis == 0)
          {
              sonido.Stop();
          }

          if (salto != 0)
          {
              sonido.Stop();
          }

          LAxis = Input.GetAxis("Lateral");
          if (LAxis < 0 || LAxis > 0)
          {
              transform.Translate(1f * velocidad * Time.deltaTime * LAxis, 0, 0);
              if (!sonido.isPlaying)
              {
                  sonido.Play();
              }
          }*/
        #endregion

        if (Input.GetKeyDown(KeyCode.R))
            {
                transform.position = checkpointPequeño;
                Pausa.vecesVisto++;
            }
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
            if (salto)
            {
                anim.SetTrigger("Salto");
                gravity.y = fSalto;
                sonidoBis.PlayOneShot(sonidoSalto);
                anim.SetBool("Suelo", false);
                salto = false;
            }
        }   
        moveDirection += gravity;

       
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
        moveDirection.x *= moveSpeed ;
        moveDirection.z *= moveSpeed ;
    }

    void PJAngle()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(lookingDirection), Time.deltaTime * rotateSpeed);
    }

    void OnControllerColliderHit()
    {
        salto = false;
        anim.SetBool("Suelo", true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            checkpointPequeño = other.transform.position;
            StartCoroutine("Guarda");
        }

        if(other.CompareTag("Plataforma Movil"))
        {
            gameObject.transform.parent = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Plataforma Movil"))
        {
            gameObject.transform.parent = GameObject.Find("Personajes").transform;
        }
    }

    IEnumerator Guarda()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("Manager").GetComponent<CargarGuardar>().Guardar();
    }
}
