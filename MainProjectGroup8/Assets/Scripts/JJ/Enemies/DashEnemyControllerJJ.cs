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

	[SerializeField]
	private CommandContainer commandContainer;

	private void Update()
	{
		if (proximityDetector.DetectedPlayer)
		{
			var dir = proximityDetector.PlayerTransform.position - transform.position;
			var distanceToPlayer = Vector2.Distance(transform.position, proximityDetector.PlayerTransform.position);
			commandContainer.MoveCommand = dir.normalized;

			if (proximityDetector.DetectedPlayer)
			{
				if (distanceToPlayer < stopDistanceBeforeDash)
				{
					if (!commandContainer.DenyMovementCommand)
					{
						myRigidBody.velocity = Vector3.zero;
					}

					commandContainer.DashCommand = true;
				}
				else
				{
					myRigidBody.velocity = commandContainer.MoveCommand*movementSpeed;
				}
			}
		}
	}
}
