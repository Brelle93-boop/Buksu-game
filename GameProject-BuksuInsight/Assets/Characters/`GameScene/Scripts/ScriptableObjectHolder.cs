using UnityEngine;

public class ScriptableObjectHolder : MonoBehaviour
{
    [Header("Put your Scriptable Objects here")]
    public ScriptableObject[] scriptableObjects;

    private void Awake()
    {
        // Keeps references alive in build
        foreach (ScriptableObject so in scriptableObjects)
        {
            if (so != null)
            {
                Debug.Log("Loaded Scriptable Object: " + so.name);
            }
        }
    }
}