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
	public bool LShiftSprint { get; private set; }

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
			if (pressTime < pressTimeTolerance)
			{
				pressTime += Time.deltaTime;
			}
			else
			{
				LShiftSprint = true;
			}
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			LShiftSprint = false;

			if (pressTime < pressTimeTolerance)
			{
				LShiftDash = true;
			}

			pressTime = 0f;
		}
	}
}
