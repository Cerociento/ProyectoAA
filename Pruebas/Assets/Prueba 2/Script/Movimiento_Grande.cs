using UnityEngine;
using System.Collections;

public class Movimiento_Grande : MonoBehaviour 
{
    [SerializeField]
    float velocidad = 1f;
    float ZAxis = 0f;
    float YAxis;

    [SerializeField]
    Transform HorizontalCamara;
    [SerializeField]
    Transform CamCamera;
    [SerializeField]
    float velCamara;
    float AxisCam = 0;

    public void Update()
    {
        if (!Laser.paraMover)
        {
            YAxis = Input.GetAxis("Horizontal");
            ZAxis = Input.GetAxis("Vertical");
            if (ZAxis > 0 && Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * ZAxis);
                transform.eulerAngles = new Vector3(0, CamCamera.transform.eulerAngles.y, 0f);

            }
            else if (ZAxis < 0 && Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * -ZAxis);
                transform.eulerAngles = new Vector3(0, CamCamera.transform.eulerAngles.y - 180, 0f);

            }

            if (YAxis < 0 && Input.GetKey(KeyCode.A))
            {
                transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * -YAxis);
                transform.eulerAngles = new Vector3(0, HorizontalCamara.transform.eulerAngles.y - 180, 0f);
            }
            else if (YAxis > 0 && Input.GetKey(KeyCode.D))
            {
                transform.Translate(0, 0f, 1f * velocidad * Time.deltaTime * YAxis);
                transform.eulerAngles = new Vector3(0, HorizontalCamara.transform.eulerAngles.y, 0f);
            }
        }

        AxisCam = Input.GetAxis("Horizontal");
        if (AxisCam < 0 && Input.GetKey(KeyCode.LeftArrow) || AxisCam > 0 && Input.GetKey(KeyCode.RightArrow))
        {
            HorizontalCamara.RotateAround(transform.position, Vector3.up * -AxisCam,velCamara );
        }
    }
}
