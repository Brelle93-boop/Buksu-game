using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDelay : MonoBehaviour
{
    public float range = 5;
    public float yOffset = 1.0f; // Y-axis offset
    public float xOffset = 0.0f; // X-axis offset
    public float activationTime = 2.0f; // Time required to activate the button
    public GameObject buttonObject; // Reference to your button object
    private bool isHit;
    private float hitTimer;

    // Update is called once per frame
    void Update()
    {
        // Calculate the starting position of the ray with the desired offsets
        Vector3 rayStartPosition = transform.position + new Vector3(xOffset, yOffset, 0);

        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(rayStartPosition, transform.TransformDirection(direction * range));
        Debug.DrawRay(rayStartPosition, transform.TransformDirection(direction * range));

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "CameraCube")
            {
                isHit = true;
                hitTimer += Time.deltaTime;

                // Show the button after 2 seconds of continuous hit
                if (isHit && hitTimer >= activationTime)
                {
                    buttonObject.SetActive(true);
                }
            }
        }
        else
        {
            // If the ray moves away or does not hit, reset the timer and deactivate the button
            isHit = false;

            if (hitTimer >= activationTime)
            {
                hitTimer = 0f;
                buttonObject.SetActive(false);
            }
        }
    }
}