using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
	[SerializeField]
	private SceneHandler sceneHandler;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			
			sceneHandler.LoadScene();
		}
	}
}
