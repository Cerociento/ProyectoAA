using UnityEngine;
using System.Collections;

public class RotacionCamara : MonoBehaviour 
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float velocidadArrow;

    [SerializeField]
    float velocidadScroll;
    float Camar;
    Vector3 rango;
    Vector3 rotacion;
    Vector3 posicion;

    float verticalAxis;   


    void Update()
    {
        
        player = Camara.Target;
        posicion = new Vector3(player.position.x, player.position.y+3, player.position.z);
    }


    void LateUpdate()
    {
        verticalAxis = Input.GetAxis("Vertical");
        Camar = Input.GetAxis("Mouse ScrollWheel");
        
        if (Camar > 0|| Camar < 0) 
        {
            Camera.main.transform.Translate(new Vector3(0,transform.position.y*Camar*velocidadScroll*Time.deltaTime, 0));
            rango = transform.position;
            rango.x = Mathf.Clamp(transform.position.x, transform.parent.position.x,transform.parent.position.x);
            rango.y = Mathf.Clamp(transform.position.y, 3, 20);
            rango.z = Mathf.Clamp(transform.position.z, transform.parent.position.z, transform.parent.position.z);
            transform.position = rango;
            
            transform.LookAt(posicion);
        }

       if (verticalAxis > 0 && Input.GetKey(KeyCode.UpArrow) ||verticalAxis < 0 && Input.GetKey(KeyCode.DownArrow))
        {
            Camera.main.transform.Translate(new Vector3(0, transform.position.y * verticalAxis*velocidadArrow*Time.deltaTime, 0));
            rango = transform.position;
            rango.x = Mathf.Clamp(transform.position.x, transform.parent.position.x, transform.parent.position.x);
            rango.y = Mathf.Clamp(transform.position.y, 3, 20);
            rango.z = Mathf.Clamp(transform.position.z, transform.parent.position.z, transform.parent.position.z);
            transform.position = rango;
            transform.LookAt(posicion);
        }
    }




}
