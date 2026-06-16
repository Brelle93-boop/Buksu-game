using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocation : MonoBehaviour
{
    public PlayerData playerData;

    // Called when the game starts
    public void Start()
    {
        LoadPlayerPosition();
    }

    // Called when the application is closed
    public void OnApplicationQuit()
    {
        SavePlayerPosition();
    }

    // Save the player position to the PlayerData
    public void SavePlayerPosition()
    {
        playerData.lastPosition = transform.position;
    }

    // Load the player position from the PlayerData
    public void LoadPlayerPosition()
    {
        if (playerData != null)
        {
            transform.position = playerData.lastPosition;
        }
    }

    // Save a custom location for the player
    public void SaveCustomPosition(Vector3 customPosition)
    {
       // playerData.customPosition = customPosition;
        playerData.lastPosition = customPosition;
    }

    // Load a custom location for the player
    public void LoadCustomPosition()
    {
        if (playerData != null)
        {
            transform.position = playerData.customPosition;
        }
    }
}