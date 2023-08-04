using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gembar2 : MonoBehaviour
{
    public Button targetButton;
    public static gembar2 Instance { get; private set; }
    public TMP_Text Gem_Text; // Reference to the UI Text element

    private int maxGems = 3; // Maximum number of gems, adjust this as needed

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

    public void UpdateGem2Count(int collectedGems)
    {
        if (Gem_Text != null && collectedGems<=3)
        {
            Gem_Text.SetText(collectedGems.ToString() + " / " + maxGems.ToString());
        }

        if(collectedGems==3 && !targetButton.interactable){
            targetButton.interactable = true;
        }
    }

    public void Enable2Button(){
        targetButton.interactable = false;
    }
}
