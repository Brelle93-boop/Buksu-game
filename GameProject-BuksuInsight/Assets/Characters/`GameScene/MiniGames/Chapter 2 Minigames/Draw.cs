using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public Material lineMaterial;
    public float lineSize = 0.1f;
    public Color lineColor = Color.black;

    private LineRenderer currentLine;
    private List<Vector3> linePositions;
    private RenderTexture doodleTexture;

    void Start()
    {
        linePositions = new List<Vector3>();

        // Create or assign a RenderTexture for drawing.
        doodleTexture = new RenderTexture(1024, 1024, 0);
        lineMaterial.mainTexture = doodleTexture;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Perform a raycast to check if the mouse is over the DoodleObject.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo) && hitInfo.transform.CompareTag("DoodleObject"))
            {

                CreateNewLine();
            }
        }

        if (Input.GetMouseButton(0))
        {

            // Check if the mouse is still over the DoodleObject.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo) && hitInfo.transform.CompareTag("DoodleObject"))
            {

                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10.0f; // Distance from the camera to the doodling plane
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                UpdateLine(worldPos);
            }
        }
    }

    void CreateNewLine()
    {
        GameObject lineObject = new GameObject("Line");
        currentLine = lineObject.AddComponent<LineRenderer>();
        currentLine.material = lineMaterial;
        currentLine.startWidth = lineSize;
        currentLine.endWidth = lineSize;
        currentLine.startColor = lineColor;
        currentLine.endColor = lineColor;
        linePositions.Clear();
    }

    void UpdateLine(Vector3 newPosition)
    {
        linePositions.Add(newPosition);
        currentLine.positionCount = linePositions.Count;
        currentLine.SetPositions(linePositions.ToArray());
    }
}
