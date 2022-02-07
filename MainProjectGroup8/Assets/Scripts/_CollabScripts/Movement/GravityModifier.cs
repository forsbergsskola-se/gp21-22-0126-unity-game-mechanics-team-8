using UnityEngine;

public class GravityModifier : MonoBehaviour
{
	[SerializeField]
	private Rigidbody myRigidBody;

	[SerializeField]
	private float gravityFallMultiplier;

	[SerializeField]
	private CommandContainer commandContainer;

	private void Update()
	{
		if (myRigidBody.velocity.y < 0)
		{
			myRigidBody.velocity += Vector3.up*Physics.gravity.y*(gravityFallMultiplier - 1)*Time.deltaTime;
		}
		else if (myRigidBody.velocity.y > 0 && !commandContainer.JumpCommandUp)
		{
			myRigidBody.velocity += Vector3.up*Physics.gravity.y*(gravityFallMultiplier - 1)*Time.deltaTime;
		}
	}
}
