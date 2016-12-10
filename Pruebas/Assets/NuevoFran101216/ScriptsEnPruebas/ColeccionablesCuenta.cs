using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColeccionablesCuenta : MonoBehaviour {

	[SerializeField]
	Text texto;
	[SerializeField]
	int coleccionables;
	[SerializeField]
	[Range (0,50)]
	public static int recogidos;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		texto.text=recogidos+" / "+coleccionables;
	}
}
		
