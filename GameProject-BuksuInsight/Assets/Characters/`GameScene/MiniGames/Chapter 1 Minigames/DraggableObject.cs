using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggableObject : MonoBehaviour
{
    private Vector2 startPosition;
    private bool isDragging;

    void Start()
    {
        startPosition = transform.position;
    }

    void

Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    isDragging = true;
                    startPosition = transform.position;
                }
            }
        }

        if (isDragging)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            isDragging = false;
        }
    }
}