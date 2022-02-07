using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousRotation : MonoBehaviour
{
	[SerializeField]
	private float rotationSpeed = 300f;
	private void Update()
	{
		transform.Rotate(0,0,rotationSpeed*Time.deltaTime);
	}
}
