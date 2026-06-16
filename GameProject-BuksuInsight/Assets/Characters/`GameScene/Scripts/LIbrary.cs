using UnityEngine;
using UnityEngine.SceneManagement;

public class LIbrary : MonoBehaviour
{
    public string nextSceneName;
    public GameObject objectToDestroy;
    public GameObject Enter;
    public PlayerLocation playerLocation;
    public Vector3 customSavePosition;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Enter.SetActive(true);
            

            //SceneManager.LoadScene(nextSceneName);
            //Destroy(objectToDestroy, 3f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Enter.SetActive(false);
        }
    }

    public void EnterLibrary()
    {
        SceneManager.LoadScene(nextSceneName);
        Destroy(objectToDestroy, 3f);
        playerLocation.SaveCustomPosition(customSavePosition);
    }

    /*  void Update()
      {
          // Check for input to switch scenes (for example, the space key)
          if (Input.GetKeyDown(KeyCode.Space))
          {
              // Load the next scene
              SceneManager.LoadScene(nextSceneName);
          }
      }*/
}
