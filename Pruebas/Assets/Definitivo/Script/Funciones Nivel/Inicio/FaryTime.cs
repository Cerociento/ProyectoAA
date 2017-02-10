using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class FaryTime : MonoBehaviour {

    [SerializeField]
    AudioMixerGroup audi;
    [SerializeField]
    GameObject faryTime;
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.T) && Input.GetKeyDown(KeyCode.F))
        {
            audi.audioMixer.SetFloat("Master", -80);
            faryTime.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.T) && Input.GetKeyDown(KeyCode.F))
        {
            audi.audioMixer.SetFloat("Master", 0);
            faryTime.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
