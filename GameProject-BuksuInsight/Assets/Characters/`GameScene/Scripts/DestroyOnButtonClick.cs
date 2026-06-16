using UnityEngine;

public class DestroyOnButtonClick : MonoBehaviour
{
    [Tooltip("Assign the object or UI element you want to destroy")]
    public GameObject objectToDestroy;

    public void DestroyObject()
    {
        // Only allow this in Play Mode
        if (Application.isPlaying)
        {
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
                Debug.Log(objectToDestroy.name + " has been destroyed.");
            }
            else
            {
                Debug.LogWarning("No object assigned to destroy!");
            }
        }
        else
        {
            Debug.Log("This action only works in Play Mode.");
        }
    }
}
