using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GemBar : MonoBehaviour
{
    public TMP_Text Gem_Text; // Reference to the UI Text element

    private int maxGems = 5; // Maximum number of gems, adjust this as needed
    public int collectedGems = 0; // Current number of collected gems

    // Function to update the gem count display
    public void UpdateGemCount(int gemsCollected)
    {
        collectedGems = gemsCollected;

        // Update the gem count text
        if (Gem_Text != null)
        {
            Gem_Text.SetText("Gems: " + collectedGems.ToString() + " / " + maxGems.ToString());
        }
    }
}
