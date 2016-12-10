using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class vecesMuerto : MonoBehaviour {

	[SerializeField]
	public static int vecesVisto;
	[SerializeField]
	Text texto;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		texto.text="Has perdido "+vecesVisto+" veces";
	}
}
