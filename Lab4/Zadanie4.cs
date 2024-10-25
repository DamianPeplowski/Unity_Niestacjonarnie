using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
   
    public Transform player;
    public float czułosc = 200;
    private float xRotation = 0f;

    void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
       
        float mouseXMove = Input.GetAxis("Mouse X") * czułosc * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * czułosc * Time.deltaTime;
        player.Rotate(Vector3.up * mouseXMove);

        xRotation -= mouseYMove;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
