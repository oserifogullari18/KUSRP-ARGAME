using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour
{
    public int numberOfGemsCollected = 0;
    public GemBar gemBar;

    public void CollectGem()
    {
        numberOfGemsCollected++;
        //Debug.Log(numberOfGemsCollected);
        gemBar.UpdateGemCount(numberOfGemsCollected);
    }
}
