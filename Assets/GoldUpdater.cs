using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUpdater : MonoBehaviour
{
    [SerializeField] IntVariable playerGold = default;
    [SerializeField] IntReference StartingGold = default;
    Text myText;

    private void Awake()
    {
        playerGold.Value = StartingGold.Value;
        myText = GetComponentInChildren<Text>();
        UpdateText();
    }
    public void UpdateText()
    {
        myText.text = "Gold: " + playerGold.Value;
    }

}
