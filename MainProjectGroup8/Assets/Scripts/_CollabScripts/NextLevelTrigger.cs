using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
	[SerializeField]
	private SceneLoader sceneLoader;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			
			sceneLoader.LoadScene();
		}
	}
}
