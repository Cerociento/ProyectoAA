using UnityEngine;
using System.Collections;

public class Transparente : MonoBehaviour
{

   // RayoParaTransparencia paredes;
    [SerializeField]
    bool puertaDetectada;
    [SerializeField]
    float alfa;

    void Update()
    {
        for (int m = 0; m < GetComponent<Renderer>().materials.Length; m++)
        {
            if (GetComponent<Renderer>().materials[m].color.a < 1)
                GetComponent<Renderer>().materials[m].shader = Shader.Find("Legacy Shaders/Transparent/Diffuse");
            else
                GetComponent<Renderer>().materials[m].shader = Shader.Find("Legacy Shaders/Bumped Diffuse");

            if (puertaDetectada)
            {
                if (GetComponent<Renderer>().materials[m].color.a > alfa)
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Detector"))
        {
            puertaDetectada = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Detector"))
        {
            puertaDetectada = false;
        }
    }


}
