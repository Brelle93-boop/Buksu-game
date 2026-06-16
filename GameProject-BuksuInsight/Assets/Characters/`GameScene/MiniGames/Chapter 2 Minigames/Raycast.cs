using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast: MonoBehaviour
{
   
    public float range = 5;
    public float yOffset = 1.0f; // Adjust this value to change the Y-axis offset
    public float xOffset = 0.0f;
    public GameObject button;
    public GameObject targetGameObject; // Reference to the GameObject you want to activate
    public GameObject targetGameObject2;
    public Camera mainCamera;      // The main camera
    public Camera targetCamera;    // The camera you want to switch to
    public Button switchButton;    // The UI button to switch back to the main camera
    public Image targetImage;      // Reference to the Image component you want to deactivate
    public Image targetImage2;
    


    private bool isTargetCameraActive = false;
    private bool isRaycastingActive = true;

    void Start()
    {
        // Attach a method to be called when the button is clicked
        switchButton.onClick.AddListener(SwitchToMainCamera);
    }


    // Update is called once per frame
    void Update()
    {

        if (!isRaycastingActive)
            return;


        Vector3 rayStartPosition = transform.position + new Vector3(xOffset, yOffset, 0);
        Vector3 direction = Vector3.forward;

        Ray theRay = new Ray(rayStartPosition, transform.TransformDirection(direction * range));

        Debug.DrawRay(rayStartPosition, transform.TransformDirection(direction * range));

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            button.SetActive(false);


            //if (hit.collider.tag == "CameraCube")
            if (hit.collider.tag == "Player")
            {
               

                print("Player hit");
                button.SetActive(true);
                SwitchCamera(targetCamera);

                // Activate the target game object
                if (targetGameObject != null)
                {
                    targetGameObject.SetActive(true);
                }

                if (targetGameObject2 != null)
                {
                    targetGameObject2.SetActive(true);
                }

                //Destroy(hit.collider.gameObject);
                //Destroy(gameObject);
                isRaycastingActive = false;

                // Deactivate the Image component
                if (targetImage != null)
                {
                    targetImage.gameObject.SetActive(false);
                }

                if (targetImage2 != null)
                {
                    targetImage2.gameObject.SetActive(true);
                }

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

    void SwitchToMainCamera()
    {
        // Switch back to the main camera when the button is clicked
        SwitchCamera(mainCamera);

        // Re-enable raycasting for this object
        //isRaycastingActive = true;

        // Deactivate the target game object when switching back to the main camera
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(false);
        }

       

    }

}
