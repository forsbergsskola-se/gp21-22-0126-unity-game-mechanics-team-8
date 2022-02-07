using System;
using UnityEngine;

public class SprintEnemyControllerJJ : MonoBehaviour
{
	[SerializeField]
	private CommandContainer commandContainer;
 
	[SerializeField]
	private Rigidbody myRigidBody;

	[SerializeField]
	private ProximityDetectorJJ proximityDetector;

	[SerializeField]
	private DestroyAfterTimeJJ destroyAfterTime;

	[SerializeField] private float killAfterLifetime;
	private void Update()
	{
		if (proximityDetector.DetectedPlayer)
		{
			myRigidBody.useGravity = true;
			commandContainer.MoveDirectionCommand = Vector3.left;
			commandContainer.SprintCommand = true;
			destroyAfterTime.DestroyAfterTime(killAfterLifetime);
		}
	}
}
