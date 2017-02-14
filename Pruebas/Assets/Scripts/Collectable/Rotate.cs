using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	[Range(0.0f, 50.0f)]
	public float speed = 1.0f;

    [Range(0, 10)]
    [SerializeField]
    float parpadeo;

    [SerializeField]
    GameObject luzParpadeo;
	
	void Update () {
		this.transform.Rotate (0.0f, this.speed*Time.deltaTime, 0.0f);
        luzParpadeo.GetComponent<Light>().intensity = parpadeo;

       /* for (float i = 0; i <=8 ; i++)
        {
            if (i >= 8)
            {
                i = 0;
            }
            else
            {
                parpadeo += 0.2f*Time.deltaTime;
            }
        }*/
	}
}
