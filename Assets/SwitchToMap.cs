using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToMap : MonoBehaviour{
	public void ChangeScene()
	{
		SceneManager.LoadScene (sceneBuildIndex:1);
	}

}