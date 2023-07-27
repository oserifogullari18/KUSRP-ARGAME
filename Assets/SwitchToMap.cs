using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour{

/*	public static Scene Manager Instance;

	private void Awake(){

		Instance = this;

	}

	private enum Scene{
		Scene1,
		map
	}
*/
	public void ChangeScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}

}