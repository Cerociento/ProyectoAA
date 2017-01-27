using UnityEngine;
using System.Collections;

public class Advertencia_auto : MonoBehaviour 
{
    [SerializeField]
    Animator inicio;

    void Start()
    {
        StartCoroutine("QuitarAdvertencia");
    }

    IEnumerator QuitarAdvertencia()
    {
        yield return new WaitForSeconds(3);
        inicio.SetTrigger("Activa");
        gameObject.SetActive(false);
    }
}
