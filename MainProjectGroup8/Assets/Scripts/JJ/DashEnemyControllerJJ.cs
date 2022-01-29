using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemyControllerJJ : MonoBehaviour
{
	[SerializeField]
	private Rigidbody myRigidBody;
	[SerializeField]
	private ProximityDetectorJJ proximityDetector;

	[SerializeField]
	private float movementSpeed = 5f;

	[SerializeField]
	private float stopDistanceBeforeDash = 5f;
	private void Update()
	{
		if (proximityDetector.DetectedPlayer)
		{
		transform.LookAt(proximityDetector.Playertransform);

		if (Vector2.Distance(transform.position, proximityDetector.Playertransform.position) < 5f)
		{
			myRigidBody.velocity = Vector3.zero; 
			//initiate dash routine
		}
		else
		{
			myRigidBody.velocity = transform.forward*movementSpeed;
		}
 
		} 
	}
}