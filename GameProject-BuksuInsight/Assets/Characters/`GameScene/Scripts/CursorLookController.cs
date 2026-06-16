using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CursorLookController : MonoBehaviour
{
    [Header("Camera Setup")]
    public Transform cameraTransform;
    public Transform playerBody;
    public float sensitivity = 0.15f;

    [Header("Look Input Action")]
    public InputActionReference lookAction;
    public InputActionReference clickAction;

    [Header("Movement Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference jumpAction;
    public InputActionReference sprintAction;   // optional

    float xRotation = 0f;

    void Start()
    {
        LockCursor(); // Start in FPS mode
    }

    void Update()
    {
        HandleCursorState();
        HandleCameraLook();
    }

    // ----------------------------------------------------------
    //  🖱 CURSOR / UI LOGIC
    // ----------------------------------------------------------
    void HandleCursorState()
    {
        // ESC unlocks cursor
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            UnlockCursor();

        // Left click behavior
        if (clickAction.action.WasPerformedThisFrame())
        {
            if (IsPointerOverUI())
                UnlockCursor();
            else
                LockCursor();
        }

        Cursor.visible = (Cursor.lockState != CursorLockMode.Locked);
    }

    // ----------------------------------------------------------
    //  🎥 CAMERA LOOK
    // ----------------------------------------------------------
    void HandleCameraLook()
    {
        if (Cursor.lockState != CursorLockMode.Locked) return;
        if (!lookAction.action.enabled) return;

        Vector2 lookDelta = lookAction.action.ReadValue<Vector2>() * sensitivity;

        float mouseX = lookDelta.x;
        float mouseY = lookDelta.y;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // ----------------------------------------------------------
    //  🔒 CURSOR LOCK / UNLOCK + INPUT MANAGEMENT
    // ----------------------------------------------------------
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Re-enable inputs
        lookAction.action.Enable();
        moveAction?.action.Enable();
        jumpAction?.action.Enable();
        sprintAction?.action.Enable();
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Disable all gameplay inputs
        lookAction.action.Disable();
        moveAction?.action.Disable();
        jumpAction?.action.Disable();
        sprintAction?.action.Disable();
    }

    // ----------------------------------------------------------
    //  🧰 UI CHECK
    // ----------------------------------------------------------
    bool IsPointerOverUI()
    {
        if (EventSystem.current == null) return false;

        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Mouse.current.position.ReadValue()
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }
}