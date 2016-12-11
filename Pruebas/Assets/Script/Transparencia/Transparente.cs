using UnityEngine;
using System.Collections;

public class Transparente : MonoBehaviour {

    RayoParaTransparencia paredes;

    void Start () {
        GameObject cam = GameObject.Find("Cam");
        paredes = cam.GetComponent<RayoParaTransparencia>();
	}
	
	// Update is called once per frame
	void Update () {
        for(int m =0; m< GetComponent<Renderer>().materials.Length; m++)
        {
            if (GetComponent<Renderer>().materials[m].color.a < 1)
                GetComponent<Renderer>().materials[m].shader = Shader.Find("Legacy Shaders/Transparent/Diffuse");
            else
                GetComponent<Renderer>().materials[m].shader = Shader.Find("Legacy Shaders/Diffuse");

            if (paredes.rayo.transform == transform)
            {
                if (GetComponent<Renderer>().materials[m].color.a > .1f)
                {
                    Color cor = GetComponent<Renderer>().materials[m].color;
                    cor.a -= 0.02f;
                    GetComponent<Renderer>().materials[m].color = cor;
                }
            }
            else
            {
                if (GetComponent<Renderer>().materials[m].color.a < 1)
                {
                    Color cor = GetComponent<Renderer>().materials[m].color;
                    cor.a += .02f;
                    GetComponent<Renderer>().materials[m].color = cor;
                }
            }

           
        }
	
	}
}
