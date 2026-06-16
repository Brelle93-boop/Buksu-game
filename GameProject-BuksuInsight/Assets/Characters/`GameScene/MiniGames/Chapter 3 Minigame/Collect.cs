using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public GameObject CollectButton;
    public Text counterText;  // Reference to your UI Text component
    public GameObject targetGameObject; // The game object you want to activate
    private int collectCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectButton.SetActive(false);
        }
    }

    // Called when the CollectButton is tapped
    public void OnCollectButtonTap()
    {
        IncreaseCounter();
    }

    private void IncreaseCounter()
    {
        collectCount++;
        UpdateCounterText();

        // Check if collectCount has reached 12
        if (collectCount == 12)
        {
            // Activate the specified game object
            if (targetGameObject != null)
            {
                targetGameObject.SetActive(true);
            }
        }
    }

    private void UpdateCounterText()
    {
        if (counterText != null)
        {
            counterText.text = "Collected: " + collectCount.ToString();
        }
    }
}