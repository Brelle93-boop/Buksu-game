using System.Collections;
using UnityEngine;

public class UITransitionManager : MonoBehaviour
{
    public GameObject currentPanel; // The current active UI panel
    public GameObject nextPanel;    // The next UI panel to show
    public float delay = 5f;        // Delay in seconds before transitioning

    // Method to start the transition
    public void OnButtonClick()
    {
        StartCoroutine(TransitionToNextPanel());
    }

    // Coroutine for delaying the UI transition
    private IEnumerator TransitionToNextPanel()
    {
        // Optional: Do something during the delay (e.g., show loading text or animation)
        Debug.Log("Delay started...");

        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Deactivate the current panel
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }

        // Activate the next panel
        if (nextPanel != null)
        {
            nextPanel.SetActive(true);
        }

        Debug.Log("Transition completed.");
    }
}
