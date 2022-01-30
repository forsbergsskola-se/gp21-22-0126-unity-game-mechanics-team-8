using System;
using UnityEngine;

public class PlayerInputControllerJJ : MonoBehaviour
{
	[SerializeField]
	private float pressTimeTolerance = 0.5f;

	private float pressTime;

	public float MoveInputHorizontal { get; private set; }
	public float MoveInputVertical { get; private set; }
	public bool JumpInputDown { get; private set; }
	public bool JumpInputUp { get; private set; }
	public bool JumpInput { get; private set; }

	public bool LShiftDash { get; private set; }

	private void Update()
	{
		MoveInputHorizontal = Input.GetAxisRaw("Horizontal");
		MoveInputVertical = Input.GetAxisRaw("Vertical");
		JumpInputDown = Input.GetKeyDown(KeyCode.Space);
		JumpInputUp = Input.GetKeyUp(KeyCode.Space);
		JumpInput = Input.GetKey(KeyCode.Space);
		
		LShiftDash = false;

		if (Input.GetKey(KeyCode.LeftShift))
		{
			Console.WriteLine("yes");

			if (pressTime < pressTimeTolerance)
			{
				pressTime += Time.deltaTime;
			}
			else
			{
				//Sprint dash here
				Debug.Log("Call sprint here");
			}
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			if (pressTime < pressTimeTolerance)
			{
				LShiftDash = true;
			}

			pressTime = 0f;
		}
	}
}
