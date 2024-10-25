using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInSquare : MonoBehaviour
{
    private Rigidbody rb;             
    public float sideLength = 10.0f;  
    public float moveSpeed = 2.0f;    
    private int cornerCount = 0;      
    private Vector3 startPosition;    
    private Vector3 targetPosition;   
    private bool isMoving = true;   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        targetPosition = startPosition + transform.forward * sideLength;  
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
           
            MoveTowardsTarget();
        }
        else
        {

            RotateAtCorner();
        }
    }

    void MoveTowardsTarget()
    {
        rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime));

        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            isMoving = false;  
        }
    }

    void RotateAtCorner()
    {
        transform.Rotate(0, 90, 0);

        targetPosition = transform.position + transform.forward * sideLength;
        isMoving = true;  

        cornerCount++;
        if (cornerCount >= 4)
        {
            cornerCount = 0;  
        }
    }
}
