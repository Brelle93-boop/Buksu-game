using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;      // The main camera
    public Camera targetCamera;    // The camera you want to switch to
    public KeyCode switchKeyCode;  // The key to switch back to the main camera

    private bool isTargetCameraActive = false;

    void Update()
    {
        if (!isTargetCameraActive)
        {
            // Cast a ray from the main camera's position and forward direction
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            RaycastHit hit;

            // Check if the ray hits the target
            if (Physics.Raycast(ray, out hit))
            {
                // Assuming the target has a tag "Target", you can customize this condition based on your game
                if (hit.collider.CompareTag("Target"))
                {
                    // Switch to the target camera
                    SwitchCamera(targetCamera);
                }
            }
        }
        else
        {
            // Check if the switch key is pressed to switch back to the main camera
            if (Input.GetKeyDown(switchKeyCode))
            {
                SwitchCamera(mainCamera);
            }
        }
    }

    void SwitchCamera(Camera newCamera)
    {
        // Disable the current active camera
        mainCamera.enabled = false;
        targetCamera.enabled = false;

        // Enable the new camera
        newCamera.enabled = true;

        // Set the active camera flag
        isTargetCameraActive = newCamera == targetCamera;
    }
}
