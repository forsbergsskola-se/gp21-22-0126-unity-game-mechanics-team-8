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
			var dir = (proximityDetector.PlayerTransform.position -transform.position);
			
			if (Vector2.Distance(transform.position, proximityDetector.PlayerTransform.position) < stopDistanceBeforeDash)
			{
				//TODO: initiate dash routine w charge-up time!
				if (!dash.AreDashing)
				{
					dash.Dash(dir);
				}
			}else
			{
				// transform.LookAt(proximityDetector.PlayerTransform);

				myRigidBody.velocity = dir.normalized*movementSpeed;
			}
		 
		}
		
	}
}
