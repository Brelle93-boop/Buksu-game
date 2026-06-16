using UnityEngine;

public class ActiveStateController : MonoBehaviour
{
    [Tooltip("Reference to the ScriptableObject that holds the active state")]
    public ActiveStateSO activeState;
    public GameObject Open;

    void Start()
    {
        // Apply the ScriptableObject's state when the scene starts
        gameObject.SetActive(activeState.isActive);
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {


        if (activeState.isActive == true)
        {
            Open.SetActive(true);
        }
        else
        {
            Open.SetActive(false);
        }
    }

    // Optional: change state at runtime
    public void SetActiveState(bool value)
    {
        activeState.isActive = value;
        gameObject.SetActive(value);
        //Open.SetActive(true);
    }
}
