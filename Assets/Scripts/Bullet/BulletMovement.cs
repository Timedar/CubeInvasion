using UnityEngine;

public class BulletMovement : MonoBehaviour
{
	[SerializeField] private Movement.MovementData movementData;
	private Movement.Movement _movement;

	private void Start()
	{
		_movement = new Movement.Movement(transform);
	}

	private void Update()
	{
		_movement.Move(new Vector3(0, 0, 1), movementData.MovementSpeed());
	}

	public void Activate(Vector3 activatePosition)
	{
		transform.position = activatePosition;
		gameObject.SetActive(true);
	}
}