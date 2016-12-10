﻿using UnityEngine;
using System.Collections;

public class Daño_Trampa : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grande"))
        {
            other.transform.position = Movimiento_Grande.checkpoint;
        }

        if (other.CompareTag("Pequeño"))
        {
            other.transform.position = Movimiento_Pequeño.checkpoint;
        }
    }

    void act()
    {

    }
}
