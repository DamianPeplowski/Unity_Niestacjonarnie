using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie6 : MonoBehaviour
{
    public Transform target;  
    public float lerpSpeed = 0.1f;  

    void Update()
    {
        float newPositionY = Mathf.Lerp(transform.position.y, target.position.y, lerpSpeed);

        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    }
}


