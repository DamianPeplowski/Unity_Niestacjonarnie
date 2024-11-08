using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoorA : MonoBehaviour
{
    private Rigidbody rb;
    public float maxDistance = 5.0f; 
    public float moveSpeed = 2.0f;    
    private Vector3 initialPosition;  
    private bool doorOpen = false;    
    private bool playerNearby = false; 

    public float detectionDistance = 3.0f; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {

        if (playerNearby && !doorOpen)
        {
            OpenDoor();
        }
        else if (!playerNearby && doorOpen)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        rb.MovePosition(transform.position + transform.right * moveSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(initialPosition, transform.position) >= maxDistance)
        {
            doorOpen = true;
        }
    }


    void CloseDoor()
    {
        rb.MovePosition(transform.position - transform.right * moveSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(initialPosition, transform.position) <= 0.1f)
        {
            doorOpen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true; 
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false; 
        }
    }
}
