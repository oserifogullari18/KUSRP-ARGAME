using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchToMain : MonoBehaviour
{
    // Start is called before the first frame update
    public void Switch()
    {
        SceneManager.LoadScene(1);
    }

    
}
