using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public string playerTag = "Player";
    public float horizontalOffset = 0f; // Optional horizontal offset
    public float verticalOffset = 0f;   // Optional vertical offset
    public float height = 10f;          // How high the camera is above the player

    private void LateUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null)
        {
            // 🟢 Make the camera follow the player's position (X and Z)
            transform.position = new Vector3(
                player.transform.position.x,
                height,
                player.transform.position.z
            );

            // 🟡 Optional: Look at the player (you can remove this if you don’t want rotation)
            transform.LookAt(player.transform.position + new Vector3(horizontalOffset, verticalOffset, 0f));
        }
    }
}