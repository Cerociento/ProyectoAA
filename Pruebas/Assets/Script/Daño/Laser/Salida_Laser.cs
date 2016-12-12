﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Salida_Laser : MonoBehaviour {
    [SerializeField]
    int numeroLlaves;
    [SerializeField]
    GameObject SalidaNivel;
   
    public static int numLlaves;
    int numContador=0;

    void Update()
    {

        if (numLlaves == numeroLlaves)
        {
            numContador++;
            if (numContador > 300)
            {
                Destroy(SalidaNivel, 4);
                numLlaves = 0;
            }
            return;
        }
        else
        {
            numContador = 0;
        }

        if (numLlaves < 0)
        {
            numLlaves = 0;
        }
    }
}
