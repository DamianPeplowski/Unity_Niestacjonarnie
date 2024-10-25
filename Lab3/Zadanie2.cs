using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRigidbody : MonoBehaviour
{
    private Rigidbody rb;             
    public float maxDistance = 10.0f; 
    public float moveSpeed = 2.0f;    

    private Vector3 initialPosition;  
    private bool movingForward = true;      
    
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        initialPosition = transform.position; 
        Debug.DrawLine(Vector3.zero, new Vector3(5, 0), Color.white, 2.5f); 
    }

    void FixedUpdate()
    {
        if (movingForward)
        {
            rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
            

            if (Vector3.Distance(initialPosition, transform.position) >= maxDistance)
            {
                movingForward = false;
            }
        }
        else
        {
            rb.MovePosition(transform.position - transform.forward * moveSpeed * Time.fixedDeltaTime);

            if (Vector3.Distance(initialPosition, transform.position) <= 0.1f)
            {
                movingForward = true; 
            }
        }
    }
}
