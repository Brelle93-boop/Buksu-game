using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    void Start()
    {
        if (!string.IsNullOrEmpty(SceneDataCarrier.objectToActivateName))
        {
            GameObject target = GameObject.Find(SceneDataCarrier.objectToActivateName);
            if (target != null)
            {
                target.SetActive(true);
            }
        }
    }
}

