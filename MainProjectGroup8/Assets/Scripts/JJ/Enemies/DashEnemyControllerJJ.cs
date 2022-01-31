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
	private ShortDashJJ dash;

	private void Update()
	{
		if (proximityDetector.DetectedPlayer)
		{
			var dir = proximityDetector.PlayerTransform.position - transform.position;
			var distanceToPlayer = Vector2.Distance(transform.position, proximityDetector.PlayerTransform.position);

			if (distanceToPlayer < stopDistanceBeforeDash)
			{
				if (!dash.AreDashing)
				{
					myRigidBody.velocity = Vector3.zero;
				}

				//TODO: initiate dash routine w charge-up time or telegraphing attack

				if (!dash.AreDashing)
				{
					dash.Dash(dir);
				}
			}
			else
			{
				myRigidBody.velocity = dir.normalized*movementSpeed;
			}
		}
	}
}
