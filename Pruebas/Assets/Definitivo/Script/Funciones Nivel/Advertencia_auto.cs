using UnityEngine;
using System.Collections;

public class Advertencia_auto : MonoBehaviour 
{

    void Start()
    {
        StartCoroutine("QuitarAdvertencia");
    }

    IEnumerator QuitarAdvertencia()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
