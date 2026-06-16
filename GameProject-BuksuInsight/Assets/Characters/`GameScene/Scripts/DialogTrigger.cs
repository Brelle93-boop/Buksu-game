using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DialogueEditor;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] public NPCConversation convo;

    public DialogNode initialDialogNode;
    public GameObject StartDialog;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartDialog.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartDialog.SetActive(false);
        }
    }

    public void StartConvo()
    {
        ConversationManager.Instance.StartConversation(convo);
    }

}

