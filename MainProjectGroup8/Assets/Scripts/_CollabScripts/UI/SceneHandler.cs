using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
 
	[SerializeField]
	private int sceneIndex;


	public void LoadScene()
	{
		Debug.Log($"Loading scene {sceneIndex}");
		SceneManager.LoadScene(sceneIndex);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R)) // Not good implementation. But it was quick!
		{
			RestartThisLevel();
		}
	}

	private void RestartThisLevel()
	{
		
		Debug.Log("Restarting Level");
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);	
	}
}
