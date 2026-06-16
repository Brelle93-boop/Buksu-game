using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDisplay : MonoBehaviour
{
    public PlayerData data;
    public Text nameText;


    // Start is called before the first frame update
    void Start()
    {
        nameText.text = data.playerName;
    }


}
