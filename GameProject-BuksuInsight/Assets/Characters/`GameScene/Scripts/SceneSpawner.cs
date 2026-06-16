using UnityEngine;

public class SceneSpawner : MonoBehaviour
{
    [Tooltip("Reference to the same SpawnData asset used in the previous scene")]
    public SpawnData spawnData;

    void Start()
    {
        if (spawnData.prefabToSpawn != null)
        {
            Instantiate(spawnData.prefabToSpawn, spawnData.spawnPosition, Quaternion.identity);
            Debug.Log(spawnData.prefabToSpawn.name + " spawned in this scene!");

            if (spawnData.clearAfterSpawn)
            {
                spawnData.prefabToSpawn = null;
            }
        }
        else
        {
            Debug.Log("No prefab set to spawn.");
        }
    }
}
