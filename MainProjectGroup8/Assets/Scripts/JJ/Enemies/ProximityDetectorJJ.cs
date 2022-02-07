using System;
using UnityEngine;

public class ProximityDetectorJJ : MonoBehaviour
{
	public bool DetectedPlayer { get; private set; }
	public Transform PlayerTransform { get; private set; }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			DetectedPlayer = true;
			PlayerTransform = other.transform;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			DetectedPlayer = false;
		}
	}
}
