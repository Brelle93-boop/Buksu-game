using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCRotate : MonoBehaviour
{
    public Transform playerTransform; // Assign the Player's transform in the Unity Editor
    public Button rotateButton; // Assign the button in the Unity Editor

    void Start()
    {
        // Attach the method to be called when the button is clicked
        rotateButton.onClick.AddListener(RotateTowardsPlayer);
    }

    void RotateTowardsPlayer()
    {
        if (playerTransform != null)
        {
            // Get the direction from this object to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            // Use LookAt to rotate the NPC towards the player
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
        else
        {
            Debug.LogError("Player transform not assigned!");
        }
    }
}