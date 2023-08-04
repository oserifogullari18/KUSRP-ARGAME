using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hornbar : MonoBehaviour
{
    public Button targetButton;
    public static hornbar Instance { get; private set; }
    public TMP_Text Horn_Text; // Reference to the UI Text element

    private int maxHorns = 3; 

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

    public void UpdateHornCount(int collectedHorns)
    {
        if (Horn_Text != null && collectedHorns<=3)
        {
            Horn_Text.SetText("Horns: " + collectedHorns.ToString() + " / " + maxHorns.ToString());
        }

        if(collectedHorns==3 && !targetButton.interactable){
            targetButton.interactable = true;
        }
    }

    public void EnableButton(){
        targetButton.interactable = false;
    }
}
