using UnityEngine;
using UnityEngine.UI;

public class SwitchToMap : MonoBehaviour
{
    public GameObject[] objectsToToggle; // List of game objects you want to enable/disable

    public GameObject[] objectsToToggle2; // List of game objects you want to enable/disable


    private bool areObjectsEnabled = true;

    private bool areObjectsEnabled2 = false;

    public void ToggleGameObjects()
    {
        areObjectsEnabled = !areObjectsEnabled;

        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(areObjectsEnabled);
        }

        areObjectsEnabled2 = !areObjectsEnabled2;

        foreach (GameObject obj in objectsToToggle2)
        {
            obj.SetActive(areObjectsEnabled2);
        }
    }

    public void ToggleGameObjects2()
    {
        areObjectsEnabled2 = !areObjectsEnabled2;

        foreach (GameObject obj in objectsToToggle2)
        {
            obj.SetActive(areObjectsEnabled2);
        }
    }
}
