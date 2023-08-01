using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gembar : MonoBehaviour
{
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
            Gem_Text.SetText("Gems: " + collectedGems.ToString() + " / " + maxGems.ToString());
        }
    }
}
