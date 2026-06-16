using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownUI : MonoBehaviour
{
    public Text counterText;       // UI Text
    public GameObject rewardUI;    // UI to activate
    public int targetCount = 5;    // Limit before UI appears

    private int currentCount = 0;

    void Start()
    {
        rewardUI.SetActive(false);
        UpdateCounterText();
    }

    public void AddCount()
    {
        currentCount++;

        UpdateCounterText();

        // Check if limit reached
        if (currentCount >= targetCount)
        {
            rewardUI.SetActive(true);
        }
    }

    void UpdateCounterText()
    {
        counterText.text = "C: " + currentCount;
    }
}