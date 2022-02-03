using UnityEngine;

public class CommandContainer : MonoBehaviour
{
	//Can be hidden later, visible for debug purposes
	public float MoveCommandHorizontal;
	public float MoveCommandVertical;
	public Vector3 MoveDirectionCommand;
	public bool JumpCommandDown;
	public bool JumpCommandUp;
	public bool JumpCommand;

	public bool DashCommand;
	public bool SprintCommand;
	public bool ChargingSprint;
	public bool DenyMoveCommand;
}
