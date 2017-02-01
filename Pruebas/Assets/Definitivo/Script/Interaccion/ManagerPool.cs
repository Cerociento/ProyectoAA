using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerPool : MonoBehaviour {
    [SerializeField]
    GameObject prefab;
    List<GameObject> cajas = new List<GameObject>();
    byte MaxBox = 1;

    public GameObject getBox()
    {
        byte index = 0;
        foreach(GameObject Box in cajas)
        {
            if (index >= MaxBox)
                break;
            if (!Box.activeSelf)
            {
                Box.transform.position = transform.GetComponentInChildren<Movimiento_Grande>().transform.GetChild(0).GetChild(2).GetChild(2).transform.position;
                Box.transform.SetParent(transform.GetComponentInChildren<Movimiento_Grande>().transform.GetChild(0).GetChild(2).GetChild(2));
                Box.SetActive(true);
                return Box;
            }
            index++;
        }
        if (cajas.Count >= MaxBox)
            return null;

        GameObject newBox = InstantiateBox();
        newBox.SetActive(true);
        return InstantiateBox(); 
    }

    GameObject InstantiateBox()
    {
        GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        obj.transform.SetParent(transform);
        cajas.Add(obj);
        return obj;  
    }


	void Start ()
    {
        for (byte i = 0; i <= 0; i++)
        {
            InstantiateBox();
        }
	}
}
