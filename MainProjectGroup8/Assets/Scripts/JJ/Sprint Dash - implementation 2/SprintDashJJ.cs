using System.Collections;
using UnityEngine;

public class SprintDashJJ : MonoBehaviour
{
	[SerializeField]
	private Rigidbody myRigidBody;

	[SerializeField]
	private float sprintSpeed = 20f;

	[SerializeField]
	private float sprintCoolDown = 2f;

	[SerializeField]
	private float afterSprintBrakeFactor = 0.2f;

	[SerializeField]
	private float sprintTime = 1f;

	private bool allowSprint = true;
	public bool AreSprinting { get; private set; }

	public void SprintDash(Vector3 dir)
	{
		if (allowSprint)
		{
			StartCoroutine(Sprint(dir));
			AreSprinting = true;
		}
	}

	private IEnumerator Sprint(Vector3 dir)
	{
		myRigidBody.velocity = new Vector3(dir.x*sprintSpeed, dir.y, 0);

		yield return new WaitForSeconds(sprintTime);

		myRigidBody.velocity *= afterSprintBrakeFactor;
		allowSprint = false;
		AreSprinting = false;
		StartCoroutine(SprintCoolDown(sprintCoolDown));
	}

	private IEnumerator SprintCoolDown(float sprintCoolDown)
	{
		yield return new WaitForSeconds(sprintCoolDown);

		allowSprint = true;
	}
}
