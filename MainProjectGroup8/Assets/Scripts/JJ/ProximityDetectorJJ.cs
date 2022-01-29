using UnityEngine;

public class ProximityDetectorJJ : MonoBehaviour
{
	public bool DetectedPlayer { get; private set; }
	public Transform Playertransform { get; private set; }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			DetectedPlayer = true;
			Playertransform = other.transform;
		}
	}
}
