using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
	[SerializeField]
	private PlayerRestartLevelEventEmitter restartLevelEventEmitter;
	[SerializeField]
	private int sceneIndex;

	private void OnEnable() => restartLevelEventEmitter.OnRestartLevel += RestartThisLevel;

	private void OnDisable() => restartLevelEventEmitter.OnRestartLevel -= RestartThisLevel;

	public void LoadScene()
	{
		Debug.Log($"Loading scene {sceneIndex}");
		SceneManager.LoadScene(sceneIndex);
	}

	 

	public void RestartThisLevel()
	{
		
		Debug.Log("Restarting Level");
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);	
	}
}
