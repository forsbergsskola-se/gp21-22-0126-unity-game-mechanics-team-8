 using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

	[SerializeField]
	private int sceneIndex;
	public void LoadScene()
	{
		Debug.Log($"Loading scene {sceneIndex}");
		SceneManager.LoadScene(sceneIndex);
	}
}
