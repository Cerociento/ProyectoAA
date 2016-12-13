using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Textos_Tutorial : MonoBehaviour {

    [SerializeField]
    GameObject tinyDoor;
    [TextArea (5,10)]
    [SerializeField]
    string texto;

    [SerializeField]
    GameObject tuto;

    bool inicia = false;
    float segundos = 5f;
    

    void Update()
    {
     if (inicia)
          {
            if (segundos <= 5)
            {
                segundos -= 1 * Time.deltaTime;
                tuto.SetActive(true);
            }
            if (segundos <= 0)
            {
                segundos = 0;
                tuto.SetActive(false);
                inicia = false;
            }
            Debug.Log(segundos);
        }
          else
          {
              segundos = 5;
          }
    }

    /*void OnTriggerExit(Collider col){
		if(gameObject.CompareTag("EsferaSalida")){
		Tutorial.cadenaTexto=" ";
		Destroy(gameObject);
		}

		if(gameObject.CompareTag("TriggerTiny")){
			Tutorial.cadenaTexto="Acércate al botón y pulsa 'E' para abrir la puerta de tu compañero. Luego, pulsa 1 para volver a él.";
			Destroy(gameObject);
		}

	}*/

    void OnTriggerEnter(Collider col){
        
        /*if(gameObject.CompareTag("GirarCamaraEntrada")){
			Tutorial.cadenaTexto="Pulsa las flechas de dirección o los botones del ratón para girar la cámara";
			Destroy(gameObject);
		}

		if(gameObject.CompareTag("GirarCamaraSalida")){
			Tutorial.cadenaTexto="";
			Destroy(gameObject);
		}

		if(gameObject.CompareTag("Ayuda")){
			Tutorial.cadenaTexto="Necesitas ayuda. Pulsa 2 para solicitarla.";
			Destroy(gameObject);
		}

		if(gameObject.CompareTag("PreCaja")){
		
			Destroy(tinyDoor);
			Destroy(gameObject);
		}
       
		if(gameObject.CompareTag("EnCaja")){
			Tutorial.cadenaTexto="Tu Compañero necesita ayuda. Mándale una caja cogiéndola del montón ('E') y suéltala en el cajón de la derecha ('E')";
			Destroy(gameObject);
		}

		if(gameObject.CompareTag("AyudaCaja1")){
			Tutorial.cadenaTexto=" ";
			Destroy(gameObject);
		}

		if(gameObject.CompareTag("AyudaCaja")){
			Tutorial.cadenaTexto="Salta encima de la caja ('Espacio') y activa el botón ('E')";
			Destroy(gameObject);
		}

		if(gameObject.CompareTag("AvisoEnemigos")){
			Tutorial.cadenaTexto="Llega al final sin que te vea el enemigo. Si coges una caja amarilla y pulsas espacio, puedes ocultarte un tiempo.";
			Destroy(gameObject);
		}

		if(gameObject.CompareTag("AvisoEnemigosFin")&& col.gameObject.CompareTag("Grande")){
			Tutorial.cadenaTexto=" ";
			Destroy(gameObject);
		}

		if(gameObject.CompareTag("FinTut")){
			Tutorial.cadenaTexto="Has completado el tutorial. Súbete en la plataforma para comenzar el primer nivel.";
			Destroy(gameObject);
		}*/

		if(gameObject.CompareTag("Finish")){
			SceneManager.LoadScene(1);

		}

        if (col.CompareTag("Grande")||col.CompareTag("Pequeño"))
        {
            segundos = 5;
            tuto.transform.GetChild(0).GetComponent<Text>().text = texto;
            inicia = true;         
        }
	}

}
