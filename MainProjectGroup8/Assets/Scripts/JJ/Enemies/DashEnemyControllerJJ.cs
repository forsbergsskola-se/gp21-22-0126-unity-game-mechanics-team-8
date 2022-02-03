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
	private CommandContainerJJ commandContainer;

	private void Update()
	{
		if (proximityDetector.DetectedPlayer)
		{
			var dir = proximityDetector.PlayerTransform.position - transform.position;
			var distanceToPlayer = Vector2.Distance(transform.position, proximityDetector.PlayerTransform.position);
			commandContainer.MoveDirectionCommand = dir.normalized;

			if (proximityDetector.DetectedPlayer)
			{
				if (distanceToPlayer < stopDistanceBeforeDash)
				{
					if (!commandContainer.DenyMoveCommand)
					{
						myRigidBody.velocity = Vector3.zero;
					}

					commandContainer.DashCommand = true;
				}
				else
				{
					myRigidBody.velocity = commandContainer.MoveDirectionCommand*movementSpeed;
				}
			}
		}
	}
}
