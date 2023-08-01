using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemmanager : MonoBehaviour
{
    private int numberOfGemsCollected = 0;
    public gembar gemBar;
    private bool collected;

    public void CollectGem(bool collected)
    {
        if(collected){
            collected=false;
            numberOfGemsCollected++;
            gemBar.UpdateGemCount(numberOfGemsCollected);
            Debug.Log(numberOfGemsCollected);
        }
        
    }
}
