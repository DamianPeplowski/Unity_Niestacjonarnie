using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Obiekt wszedł w trigger: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz się zbliżył");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz jest w triggerze");
        }
    }
}
