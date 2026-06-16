using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool isMale;
    //private string playerName; 
    public InputField nameInputField;
    public PlayerData playerData;

    public CharacterSettings characterSettings; // Reference to the ScriptableObject
    public CharacterSpawner characterSpawner; // Reference to the spawner

    //public InputField playerNameInput; // Reference to the input field for the player's name

    public void SelectMale()
    {
        isMale = true;
        
    }

    public void SelectFemale()
    {
        isMale = false;
        
    }

    //public void SetPlayerName()
    //{
     //   playerName = playerNameInput.text;
   // }

    /*public void SavePlayerName()
    {
        if (nameInputField != null && playerData != null)
        {
            playerData.playerName = nameInputField.text;
            Debug.Log("Player Name Saved: " + playerData.playerName);
        }
    }*/

    public void ProceedToNextScene()
    {
        /*if (string.IsNullOrEmpty(playerName))
        {
            // You may want to add some validation for the player's name
            Debug.LogWarning("Please enter a valid player name.");
            return;
        }*/

        // Set the character settings in the ScriptableObject
        characterSettings.isMale = isMale;

        // Set the character settings in the CharacterSpawner
        characterSpawner.characterSettings = characterSettings;

        // You can pass the player name to the next scene using PlayerPrefs or other methods
        //PlayerPrefs.SetString("PlayerName", playerName);

        SceneManager.LoadScene("MainGame");

    }


    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("U quit");
    }
}
