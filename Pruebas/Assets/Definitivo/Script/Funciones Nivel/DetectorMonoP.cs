using UnityEngine;
using System.Collections;

public class DetectorMonoP : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("DetectorMonos"))
		{
			DetectorMonos.tiny=true;
		}
	}
}
