using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gembar : MonoBehaviour
{
    public Button targetButton;
    public static gembar Instance { get; private set; }
    public TMP_Text Gem_Text; // Reference to the UI Text element

    private int maxGems = 5; // Maximum number of gems, adjust this as needed

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

    public void UpdateGemCount(int collectedGems)
    {
        if (Gem_Text != null && collectedGems<=5)
        {
            Gem_Text.SetText(collectedGems.ToString() + " / " + maxGems.ToString());
        }

        if(collectedGems==5 && !targetButton.interactable){
            targetButton.interactable = true;
        }
    }

    public void EnableButton(){
        targetButton.interactable = false;
    }
}
