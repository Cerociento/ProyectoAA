using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class Creditos : MonoBehaviour {

    [SerializeField]
    AudioMixer audioMixer;

    void Start()
    {
        gameObject.SetActive(false);
    }

	void OnEnable ()
    {
       audioMixer.SetFloat("Master", -80);
	}

    public void Vuelta()
    {
        StartCoroutine("Final");
    }

    IEnumerator Final()
    {
        yield return new WaitForSeconds(3);
        MenuFinNivel.prueba = false;
        SceneManager.LoadScene(0);
        audioMixer.SetFloat("Master", 0);
    }
}
