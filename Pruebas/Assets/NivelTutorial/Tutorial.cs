using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	[SerializeField]
	public Text texto;
	public static string cadenaTexto;

	// Use this for initialization
	void Start () {
		cadenaTexto="Pulsa W/A/S/D para moverte. Sal de la habitación.";
		texto.text=cadenaTexto;

	}
	
	// Update is called once per frame
	void Update () {
		texto.text=cadenaTexto;
	}

}
