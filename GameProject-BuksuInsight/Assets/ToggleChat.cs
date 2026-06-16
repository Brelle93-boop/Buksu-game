using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleChat : MonoBehaviour
{
    public GameObject uiPanel;          // The main UI you toggle
    public GameObject[] otherUIPanels;  // Other UI panels affected

    private bool[] previousStates;      // Store previous states

    void Start()
    {
        // Create array matching otherUIPanels length
        previousStates = new bool[otherUIPanels.Length];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            bool openMain = !uiPanel.activeSelf;

            // Toggle main UI
            uiPanel.SetActive(openMain);

            if (openMain)
            {
                // Save previous states + turn them off
                for (int i = 0; i < otherUIPanels.Length; i++)
                {
                    if (otherUIPanels[i] != null)
                    {
                        previousStates[i] = otherUIPanels[i].activeSelf; // save
                        otherUIPanels[i].SetActive(false);               // hide
                    }
                }
            }
            else
            {
                // Restore other UI back to its old state
                for (int i = 0; i < otherUIPanels.Length; i++)
                {
                    if (otherUIPanels[i] != null)
                    {
                        otherUIPanels[i].SetActive(previousStates[i]);
                    }
                }
            }
        }
    }
}

