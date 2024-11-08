using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    public List<Vector3> waypoints;     
    public float moveSpeed = 2.0f;      
    private int currentWaypointIndex = 0; 
    private bool movingForward = true;   

    void Start()
    {
        if (waypoints.Count == 0)
        {
            Debug.LogWarning("nie ma punktow");
            return;
        }

        transform.position = waypoints[0];
    }

    void Update()
    {
        if (waypoints.Count > 0)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.1f)
        {
            if (currentWaypointIndex == waypoints.Count - 1)
            {
                movingForward = false;
            }
  
            else if (currentWaypointIndex == 0)
            {
                movingForward = true;
            }

            currentWaypointIndex = movingForward ? currentWaypointIndex + 1 : currentWaypointIndex - 1;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], moveSpeed * Time.deltaTime);
    }
}
