using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private bool isFlipped = false;
    private Vector3 originalRotation;
    private Vector3 flippedRotation = new Vector3(90f, 180f, 180f);

    private float touchStartTime = 0f;
    private float touchDuration = 0.2f; // Adjust as needed for your desired time threshold

    private void Start()
    {
        originalRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStartTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {
            float touchTime = Time.time - touchStartTime;

            if (touchTime < touchDuration)
            {
                // It's a tap (short touch)
                ToggleFlip();
            }
        }

        // Check for user input (e.g., mouse drag or touch drag)
        if (Input.GetMouseButton(0))
        {
            // Dragging logic can be added here
            // For example, you can move the object by changing its position based on mouse/touch input.
        }
    }

    private void ToggleFlip()
    {
        if (isFlipped)
            transform.rotation = Quaternion.Euler(originalRotation);
        else
            transform.rotation = Quaternion.Euler(flippedRotation);

        isFlipped = !isFlipped;
    }
}
