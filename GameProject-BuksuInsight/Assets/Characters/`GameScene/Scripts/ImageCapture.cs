using UnityEngine;
using System.IO;

public class ImageCapture : MonoBehaviour
{
    // Reference to your camera
    public Camera captureCamera;

    // Specify the file path where you want to save the image
    // For Android, use the persistentDataPath
    public string filePath;

    void Start()
    {
        // For Android, use the persistentDataPath
        filePath = Path.Combine(Application.persistentDataPath, "capturedImage.png");
    }

    void Update()
    {
        // Check if the user presses a key (for example, the 'S' key)
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Perform a raycast from the camera's position
            Ray ray = captureCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            RaycastHit hit;

            // Check if the ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                // Capture the frame at the hit point
                Texture2D texture = CaptureFrameAtPoint(hit.point);

                // Save the captured frame to a file
                SaveTextureToFile(texture, filePath);
            }
        }
    }

    Texture2D CaptureFrameAtPoint(Vector3 point)
    {
        // Create a new RenderTexture and set it as the target texture of the camera
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        captureCamera.targetTexture = renderTexture;
        captureCamera.Render();

        // Calculate the screen position of the hit point
        Vector3 screenPoint = captureCamera.WorldToScreenPoint(point);

        // Create a new Texture2D and read the pixels from the RenderTexture at the hit point
        Texture2D texture = new Texture2D(1, 1, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(screenPoint.x, screenPoint.y, 1, 1), 0, 0);
        texture.Apply();

        // Reset the camera's target texture to null
        captureCamera.targetTexture = null;
        RenderTexture.active = null;

        return texture;
    }

    void SaveTextureToFile(Texture2D texture, string filePath)
    {
        // Encode the texture to a PNG file
        byte[] bytes = texture.EncodeToPNG();

        // Write the bytes to the file
        File.WriteAllBytes(filePath, bytes);

        Debug.Log("Image saved to: " + filePath);
    }
}