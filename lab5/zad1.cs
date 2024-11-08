using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.right; 
    public float moveDistance = 10.0f;           
    public float moveSpeed = 2.0f;                

    private Vector3 startPosition;                
    private bool movingForward = true;            
    private Transform playerTransform = null;     

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
 
        Vector3 previousPosition = transform.position;
        if (movingForward)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.position -= moveDirection * moveSpeed * Time.deltaTime;
            if (Vector3.Distance(startPosition, transform.position) <= 0.1f)
            {
                movingForward = true;
            }
        }

        Vector3 movementDelta = transform.position - previousPosition;

        if (playerTransform != null)
        {
            playerTransform.GetComponent<CharacterController>().Move(movementDelta);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = null; 
        }
    }
}
