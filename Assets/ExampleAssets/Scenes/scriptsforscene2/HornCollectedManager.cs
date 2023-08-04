using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HornCollectedManager : MonoBehaviour
{
    public static HornCollectedManager Instance { get; private set; }
    public TMP_Text hornCollected;

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

    public void ShowHornCollected(float duration)
    {
        hornCollected.enabled = true;
        Invoke(nameof(HideHornCollected), duration);
    }

    public void HideHornCollected()
    {
        hornCollected.enabled = false;
    }
}
