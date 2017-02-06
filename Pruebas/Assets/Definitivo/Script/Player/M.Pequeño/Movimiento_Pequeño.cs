using UnityEngine;
using System.Collections;

public class Movimiento_Pequeño : MonoBehaviour 
{
    //Movimiento
    [SerializeField]
    public float velocidad = 1f;
    public static float ZAxis = 0f;
    float YAxis;
    float LAxis;

    //Rotacion Camara
    [SerializeField]
    float velRotacion;

    //Salto
    [SerializeField]
    float fSalto;
    int salto=0;

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
    }

    void Update()
    {
        float num = GetComponent<Rigidbody>().velocity.y * Time.deltaTime;
        anim.SetFloat("EnAire", num);

        YAxis = Input.GetAxis("Horizontal");
        ZAxis = Input.GetAxis("Vertical");

        if (ZAxis > 0 && Input.GetKey(KeyCode.W) || ZAxis < 0 && Input.GetKey(KeyCode.S))
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

        if (YAxis < 0 && Input.GetKey(KeyCode.A) || YAxis > 0 && Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * velRotacion * YAxis);
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
        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (salto == 0)
                {
                anim.SetTrigger("Salto");
              //  anim.SetFloat("EnAire", num);
                GetComponent<Rigidbody>().AddForce(new Vector3(0, fSalto, 0), ForceMode.Impulse);
                salto++;
                sonidoBis.PlayOneShot(sonidoSalto);
                anim.SetBool("Suelo", false);
                    
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.position = checkpointPequeño;
                Pausa.vecesVisto++;
            }
        }

    void OnCollisionEnter()
    {
        salto = 0;
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
