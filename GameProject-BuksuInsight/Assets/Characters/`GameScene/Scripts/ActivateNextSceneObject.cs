using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ActivateNextSceneObject : MonoBehaviour
{
    public GameObject targetObjectNameInNextScene;

    public void OnButtonClick()
    {
        targetObjectNameInNextScene.SetActive(true);
    }
}
