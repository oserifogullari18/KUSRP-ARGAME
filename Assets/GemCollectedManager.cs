using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GemCollectedManager : MonoBehaviour
{
    public static GemCollectedManager Instance { get; private set; }
    public TMP_Text gemCollected;

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

    public void ShowGemCollected(float duration)
    {
        gemCollected.enabled = true;
        Invoke(nameof(HideGemCollected), duration);
    }

    public void HideGemCollected()
    {
        gemCollected.enabled = false;
    }
}
