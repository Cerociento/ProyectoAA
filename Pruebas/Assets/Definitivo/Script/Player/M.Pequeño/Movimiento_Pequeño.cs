using UnityEngine;
using System.Collections;

public class Movimiento_Pequeño : MonoBehaviour 
{
    //Movimiento
    [SerializeField]
    public float velocidad = 1f;
    float ZAxis = 0f;
    float YAxis;
    float LAxis;
    [SerializeField]
    Transform HorizontalCamara;
    [SerializeField]
    Transform CamCamera;
    float velocidadMovi;

    //Rotacion Camara
    float AxisCam = 0;
    [SerializeField]
    float velRotacion;

    [Range(-5f, 5f)]
    [SerializeField]
    float alturaCamara;

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

    void Start()
    {
        velocidadMovi = velocidad;
    }

     void Update()
    {
        #region MovimientoNormal
        YAxis = Input.GetAxis("Horizontal");
            ZAxis = Input.GetAxis("Vertical");

            if (ZAxis > 0 && Input.GetKey(KeyCode.W)|| ZAxis < 0 && Input.GetKey(KeyCode.S))
            {
            transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * ZAxis);
            //GetComponent<Rigidbody>().AddRelativeForce(0, 0, velocidad, ForceMode.VelocityChange);
           // transform.eulerAngles = new Vector3(0, CamCamera.transform.eulerAngles.y, 0f);
			if(!sonido.isPlaying){
				sonido.Play();}
            }
        /* else if (ZAxis < 0 && Input.GetKey(KeyCode.S))
         {
         transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * -ZAxis);
         //GetComponent<Rigidbody>().AddRelativeForce(0, 0, velocidad, ForceMode.VelocityChange);
         transform.eulerAngles = new Vector3(0, CamCamera.transform.eulerAngles.y - 180, 0f);
         if(!sonido.isPlaying){
             sonido.Play();}    
     }*/

        if (YAxis < 0 && Input.GetKey(KeyCode.A) || YAxis > 0 && Input.GetKey(KeyCode.D))
            {
            //transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * -YAxis);
            //GetComponent<Rigidbody>().AddRelativeForce(0, 0, velocidad, ForceMode.VelocityChange);
            //transform.eulerAngles = new Vector3(0, HorizontalCamara.transform.eulerAngles.y - 180, 0f);
            transform.Rotate(Vector3.up*velRotacion*YAxis);
			//if(!sonido.isPlaying){
			//	sonido.Play();
			//}    
		}
           /* else if (YAxis > 0 && Input.GetKey(KeyCode.D))
            {
            transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * YAxis);
            //GetComponent<Rigidbody>().AddRelativeForce(0, 0, velocidad, ForceMode.VelocityChange);
            transform.eulerAngles = new Vector3(0, HorizontalCamara.transform.eulerAngles.y, 0f);
			if(!sonido.isPlaying){
				sonido.Play();}    
		}*/

		if(YAxis==0 && ZAxis==0 && LAxis==0){
			sonido.Stop();
		}
		if(salto!=0){
			sonido.Stop();
		}
        #endregion
        /* AxisCam = Input.GetAxis("Rotacion");

         if (AxisCam < 0 ||  AxisCam > 0)
         {
             HorizontalCamara.RotateAround(transform.position, Vector3.up * AxisCam, velRotacion);
         }*/


        LAxis = Input.GetAxis("Lateral");
		if (LAxis < 0 || LAxis > 0){
            transform.Translate(1f * velocidad * Time.deltaTime * LAxis, 0, 0);
		if(!sonido.isPlaying){
			sonido.Play();}
	}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (salto == 0)
            {
                Debug.Log("No salto");
                GetComponent<Rigidbody>().AddForce(new Vector3(0, fSalto, 0), ForceMode.Impulse);
                Debug.Log("salto");
                salto++;
				sonidoBis.PlayOneShot(sonidoSalto);
            }
        }

		if(Input.GetKeyDown(KeyCode.R)){
			transform.position = checkpointPequeño;
			Pausa.vecesVisto++;
		}
    }

    void OnCollisionEnter(Collision hit)
    {
        salto = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            checkpointPequeño = other.transform.position;
            StartCoroutine("Guarda");
            print(other.transform.position + "    "+ transform.position); 
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
