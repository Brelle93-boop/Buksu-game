using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public CharacterSettings characterSettings;
    public MainMenu main;
    public GameObject Male;
    public GameObject Female;
    public GameObject Spawn;


    void Start()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        
        GameObject characterPrefab = characterSettings.isMale ? characterSettings.maleCharacterPrefab : characterSettings.femaleCharacterPrefab;

        if(characterSettings.isMale == true)
        {
            Male.SetActive(true);
            Female.SetActive(false);
        }
        else 
        {
            Female.SetActive(true);
            Male.SetActive(false);
        }

        Spawn.SetActive(false);


        if (characterPrefab != null)
        {
            Instantiate(characterPrefab, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogError("Character prefab is not assigned!");
        }
    }
}
