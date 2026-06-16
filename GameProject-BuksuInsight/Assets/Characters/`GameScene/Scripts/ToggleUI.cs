using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject uiPanel;          // the main panel you toggle
    public GameObject[] otherUIPanels;  // panels to hide when uiPanel is opened

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool newState = !uiPanel.activeSelf;

            // Toggle main panel
            uiPanel.SetActive(newState);

            // If main panel is being turned ON → hide all other UI
            if (newState)
            {
                foreach (var panel in otherUIPanels)
                {
                    if (panel != null)
                        panel.SetActive(false);
                }
            }
        }
    }
}
