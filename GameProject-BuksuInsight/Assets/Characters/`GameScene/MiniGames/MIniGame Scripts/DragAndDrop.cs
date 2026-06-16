using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public GameObject targetObject;
    public float snapDistanceThreshold = 0.5f;
    public GameObject Active1;

    void Update()
    {
        

        // Check for mouse input
        if (Input.GetMouseButtonDown(0) && !isDragging)
        {
            OnDragStart(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            OnDragEnd();
        }
        else if (isDragging)
        {
            OnDragging(Input.mousePosition);
        }

        // For touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (!isDragging)
                    {
                        OnDragStart(touch.position);
                    }
                    break;
                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        OnDragging(touch.position);
                    }
                    break;
                case TouchPhase.Ended:
                    if (isDragging)
                    {
                        OnDragEnd();
                    }
                    break;
            }
        }
    }

    void OnDragStart(Vector2 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            isDragging = true;
            offset = transform.position - hit.point;
        }
    }

    void OnDragging(Vector2 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point + offset;

            // Check if the target object is within the snapping distance
            float distanceToTarget = Vector3.Distance(targetPosition, targetObject.transform.position);
            if (distanceToTarget < snapDistanceThreshold)
            {
                // Snap to the position of the target object
                transform.position = targetObject.transform.position;
                

                // Set the dragged object as a child of the target object
                transform.parent = targetObject.transform;
                //Active1.SetActive(true);

                StartCoroutine(ShowPanelAfterDelay(1.5f)); // Display the panel after a 2-second delay


            }
            else
            {
                // If not close enough to the target, continue dragging
                transform.parent = null; // Detach from the parent
                transform.position = targetPosition;
            }
        }

        IEnumerator ShowPanelAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);

            // Display the panel after the specified delay
            Active1.SetActive(true);
        }


    }

    void OnDragEnd()
    {
       
        isDragging = false;
        //Active1.SetActive(true);
        
    }
}