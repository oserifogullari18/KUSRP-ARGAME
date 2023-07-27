using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToShooting : MonoBehaviour{
	public void ChangeSceneToShooting()
	{
		SceneManager.LoadScene (sceneBuildIndex:0);
		
	}

}