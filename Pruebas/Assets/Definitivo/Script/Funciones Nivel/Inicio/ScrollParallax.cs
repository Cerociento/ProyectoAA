using UnityEngine;
using System.Collections;

public class ScrollParallax : MonoBehaviour {
    [SerializeField]
    float velocidad = 0.1f;

    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * velocidad) % 1, 0);
    }
}
