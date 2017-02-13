using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	[Range(0.0f, 50.0f)]
	public float speed = 1.0f;
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0.0f, this.speed*Time.deltaTime, 0.0f);
	}
}
