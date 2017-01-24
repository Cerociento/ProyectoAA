﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CargarGuardar : MonoBehaviour 
{ 
     float posicionPequeñoX, posicionPequeñoY, posicionPequeñoZ;
     float posicionGrandeX, posicionGrandeY, posicionGrandeZ;
    [SerializeField]
     int nivel;
    [SerializeField]
    int vecesVisto;
    [SerializeField]
    int colecionables;
    datosJuego datos = new datosJuego();
    [SerializeField]
    GameObject imagenGuardado;
    [SerializeField]
    GameObject desactivar;

    float tiempoTotal;
    float tiempoNivel;

    public static float TTotal;
    public static float TNivel;
    public static int NNivel;

    void Awake()
    {
        nivel = SceneManager.GetActiveScene().buildIndex;

        if (File.Exists(Application.persistentDataPath + "/monosave.af") && SceneManager.GetActiveScene().buildIndex == 0)
        {
            BinaryFormatter load = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/monosave.af");
            datos = load.Deserialize(file) as datosJuego;
            nivel = datos.nivel;
            tiempoNivel = datos.tiempoNivel;
            tiempoTotal = datos.tiempoTotal;
            colecionables = datos.colecionables;
           
        }
        NNivel = nivel;
        TTotal = tiempoTotal;
        TNivel = tiempoNivel;
    }

    void Start()
    {
        posicionPequeñoX = Movimiento_Pequeño.checkpointPequeño.x;
        posicionPequeñoY = Movimiento_Pequeño.checkpointPequeño.y;
        posicionPequeñoZ = Movimiento_Pequeño.checkpointPequeño.z;
        posicionGrandeX = Movimiento_Grande.checkpointGrande.x;
        posicionGrandeY = Movimiento_Grande.checkpointGrande.y;
        posicionGrandeZ = Movimiento_Grande.checkpointGrande.z;
        TTotal = tiempoTotal;
        TNivel = tiempoNivel;
        print("Cargado datos minimos//  " +
               TTotal + " " +
               TNivel);
    }

    void Update()
    {
        posicionPequeñoX = Movimiento_Pequeño.checkpointPequeño.x;
        posicionPequeñoY = Movimiento_Pequeño.checkpointPequeño.y;
        posicionPequeñoZ = Movimiento_Pequeño.checkpointPequeño.z;
        posicionGrandeX = Movimiento_Grande.checkpointGrande.x;
        posicionGrandeY = Movimiento_Grande.checkpointGrande.y;
        posicionGrandeZ = Movimiento_Grande.checkpointGrande.z;
        nivel = SceneManager.GetActiveScene().buildIndex;
        vecesVisto = Pausa.vecesVisto;
        colecionables = Pausa.recogidos;
        tiempoTotal = Timer.tiempoTotal;
        tiempoNivel = Timer.tiempo;
        TTotal = tiempoTotal;
        TNivel = tiempoNivel;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            desactivar.SetActive(false);
        }
        else
        {
            desactivar.SetActive(true);
        }

#if UNITY_EDITOR 
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Guardar();
            imagenGuardado.SetActive(true);
            StartCoroutine("Imagen");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Cargar();
            imagenGuardado.SetActive(true);
            StartCoroutine("Imagen");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Borrar();
            imagenGuardado.SetActive(true);
            StartCoroutine("Imagen");
        }
           
#endif 

    }

    public void Guardar()
    {
        BinaryFormatter save = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/monosave.af");
        datos.posicionGrandeX = posicionGrandeX;
        datos.posicionGrandeY = posicionGrandeY;
        datos.posicionGrandeZ = posicionGrandeZ;
        datos.posicionPequeñoX = posicionPequeñoX;
        datos.posicionPequeñoY = posicionPequeñoY;
        datos.posicionPequeñoZ = posicionPequeñoZ;
        datos.nivel = nivel;
        datos.vecesVisto = vecesVisto;
        datos.colecionables = colecionables;
        datos.tiempoTotal = tiempoTotal;
        datos.tiempoNivel = tiempoNivel;
        save.Serialize(file, datos);
        file.Close();
        print("Guardado nivel" +nivel);
        imagenGuardado.SetActive(true);
        StartCoroutine("Imagen");
    } 

    public void Cargar()
    {
        if (File.Exists(Application.persistentDataPath + "/monosave.af"))
        {
            BinaryFormatter load = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/monosave.af");
            datos = load.Deserialize(file) as datosJuego;
            posicionGrandeX = datos.posicionGrandeX;
            posicionGrandeY = datos.posicionGrandeY;
            posicionGrandeZ = datos.posicionGrandeZ;
            posicionPequeñoX = datos.posicionPequeñoX;
            posicionPequeñoY = datos.posicionPequeñoY;
            posicionPequeñoZ = datos.posicionPequeñoZ;
            vecesVisto = datos.vecesVisto;
            colecionables = datos.colecionables;
            nivel = datos.nivel;
            tiempoNivel = datos.tiempoNivel;
            tiempoTotal = datos.tiempoTotal;
            print("Cargado");

            SceneManager.LoadScene(nivel);
            desactivar.SetActive(true);
            GameObject.FindWithTag("Pequeño").transform.position = new Vector3(posicionPequeñoX, posicionPequeñoY, posicionPequeñoZ);
            GameObject.FindWithTag("Grande").transform.position  = new Vector3(posicionGrandeX, posicionGrandeY, posicionGrandeZ);
            Pausa.vecesVisto = vecesVisto;
            Pausa.recogidos = colecionables;
        }
        else
        {
            print("No existe archivo");
        }
    }

    public void Borrar()
    {
        if (File.Exists(Application.persistentDataPath + "/monosave.af"))
        {
            File.Delete(Application.persistentDataPath + "/monosave.af");
            TTotal = 0;
            TNivel = 0;
            print("Borrado");
        }
    }

    IEnumerator Imagen()
    {
        yield return new WaitForSeconds(4);
        imagenGuardado.SetActive(false);
    }
}

[Serializable()]
public class datosJuego : System.Object
{
    public float posicionPequeñoX, posicionPequeñoY, posicionPequeñoZ;
    public float posicionGrandeX, posicionGrandeY, posicionGrandeZ;
    public int nivel;
    public int vecesVisto;
    public int colecionables;
    public float tiempoTotal;
    public float tiempoNivel;
}
