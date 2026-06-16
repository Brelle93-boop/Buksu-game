using UnityEngine;

public class TopDownCameraFollow : MonoBehaviour
{
    public GameObject player; // Drag your player here

    void Update()
    {
        if (player == null) return;

        // Move camera to follow player's X and Z, keep current Y height
        transform.position = new Vector3(
            player.transform.position.x,
            transform.position.y,
            player.transform.position.z
        );
    }
}
