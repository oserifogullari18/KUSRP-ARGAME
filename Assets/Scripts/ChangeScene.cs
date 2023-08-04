using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    // Change this string to the name of the scene you want to load
    public string sceneNameToLoad;

    public void LoadScene()
    {
        Application.LoadLevel(sceneNameToLoad);
    }

}
