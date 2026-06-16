using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class DialogManager_ink : MonoBehaviour
{
    public TextAsset inkJSONAsset;
    private Story story;

    public Text dialogueText;
    public Button[] optionButtons;
    public GameObject dialoguePanel;
    public Button startDialogueButton;
    public float typingSpeed = 0.02f; // Typing speed in seconds per character
    public GameObject UIPanel;
    public GameObject UIScene;

    void Start()
    {
        // Hide the dialogue panel initially
        dialoguePanel.SetActive(false);

        // Assign the start button onClick event
        startDialogueButton.onClick.AddListener(StartDialogue);
    }

    void StartDialogue()
    {
        // Show the dialogue panel
        dialoguePanel.SetActive(true);

        // Initialize the story
        StartStory();
    }

    void StartStory()
    {
        story = new Story(inkJSONAsset.text);
        RefreshView();
    }

    void RefreshView()
    {
        // Clear the UI
        dialogueText.text = "";
        foreach (Button button in optionButtons)
        {
            button.gameObject.SetActive(false);
            button.onClick.RemoveAllListeners(); // Clear previous listeners
        }

        // Start the coroutine to display text with typing effect
        StartCoroutine(DisplayNextLineWithTypingEffect());
    }

    IEnumerator DisplayNextLineWithTypingEffect()
    {
        // Display the current line of text with typing effect
        if (story.canContinue)
        {
            string textToDisplay = story.Continue();
            yield return StartCoroutine(TypeText(textToDisplay));
        }

        // Display choices, if any
        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<Text>().text = choice.text;
                int choiceIndex = i; // Local copy for the closure
                optionButtons[i].onClick.AddListener(delegate {
                    OnClickChoiceButton(choiceIndex);
                });
            }
        }
        else
        {
            // No choices left, end of the story
            dialogueText.text += "\n\n<End of conversation>";
            EndDialogue();
        }
    }

    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void OnClickChoiceButton(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        RefreshView();
    }

    void EndDialogue()
    {
        // Hide the dialogue panel
        dialoguePanel.SetActive(false);
        UIPanel.SetActive(true);
        UIScene.SetActive(true);
    }
}
