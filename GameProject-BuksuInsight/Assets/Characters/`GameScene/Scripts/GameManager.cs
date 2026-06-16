using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public DialogManager dialogManager;  // Reference to your DialogManager prefab or object

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
