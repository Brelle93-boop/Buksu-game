using UnityEngine;

public class CameraOptimization : MonoBehaviour
{
    [Tooltip("The far clipping plane distance.")]
    public float farClipDistance = 50f;
    [Tooltip("The layer mask to exclude from rendering.")]
    public LayerMask cullingMaskExclude;

    private Camera cam;

    void Start()
    {
        //cam = GetComponent();
        if (cam == null)
        {
            Debug.LogError("CameraOptimization script needs to be attached to a Camera.");
            enabled = false;
            return;
        }

        // Adjust clipping planes
        cam.nearClipPlane = 0.1f;
        cam.farClipPlane = farClipDistance;

        // Adjust culling mask
        cam.cullingMask &= ~cullingMaskExclude; // Exclude specified layers
    }
}