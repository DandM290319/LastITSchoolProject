using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    float MouseX, MouseY;
    Transform Head_tr;
    public GameObject Body;
    public float Sense;
    void Start()
    {
        Head_tr = GetComponent<Transform>();
    }

    
    void Update()
    {
        MouseX += Input.GetAxis("Mouse X") * Sense;
        MouseY += Input.GetAxis("Mouse Y") * Sense;
        MouseY = Mathf.Clamp(MouseY, -90, 90);

        Head_tr.rotation = Quaternion.Euler(-MouseY, MouseX, 0);
        Body.transform.rotation = Quaternion.Euler(0, MouseX, 0);
    }
}
