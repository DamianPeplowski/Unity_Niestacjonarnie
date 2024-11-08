using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateJumpBoost : MonoBehaviour
{
    public float silaSkoku = 3.0f; 
    private float gravityValue = -9.81f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            MoveWithCharacterController playerController = other.GetComponent<MoveWithCharacterController>();

            if (playerController != null)
            {
                playerController.BoostJump(silaSkoku, gravityValue);
            }
        }
    }
}
