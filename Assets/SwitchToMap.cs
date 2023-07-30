using UnityEngine;
using UnityEngine.UI;

public class SwitchToMap : MonoBehaviour
{
    public GameObject[] objectsToToggle; // List of game objects you want to enable/disable

    private bool areObjectsEnabled = true;

    public void ToggleGameObjects()
    {
        areObjectsEnabled = !areObjectsEnabled;

        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(areObjectsEnabled);
        }
    }
}
