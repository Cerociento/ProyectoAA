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

    public void Desactivacion()
    {
        inicio.SetTrigger("Activa");
        gameObject.SetActive(false);
    }

    IEnumerator QuitarAdvertencia()
    {
        yield return new WaitForSeconds(3);
        inicio.SetTrigger("Activa");
        gameObject.SetActive(false);
    }
}
