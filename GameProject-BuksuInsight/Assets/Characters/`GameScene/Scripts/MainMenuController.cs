using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public ActivationFlag activationFlag;

    public void StartGame()
    {
        activationFlag.shouldActivate = true;   // Set TRUE before loading scene
        //SceneManager.LoadScene("MainGame");
    }

    public void StartGameWithoutActivation()
    {
        activationFlag.shouldActivate = false;  // Optional
        //SceneManager.LoadScene("MainGame");
    }
}
