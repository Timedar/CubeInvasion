using UnityEngine;

public class BulletMovement : MonoBehaviour
{
	[SerializeField] private Movement.MovementData movementData;
	private Movement.Movement _movement;
	private bool stopMovement;

	private void Start()
	{
		_movement = new Movement.Movement(transform);
	}

	private void Update()
	{
		if (stopMovement)
			return;

		_movement.Move(new Vector3(0, 0, 1), movementData.MovementSpeed());
	}

	public void StopMovement() => stopMovement = true;

	public void Activate(Vector3 activatePosition)
	{
		stopMovement = false;
		transform.position = activatePosition;
		gameObject.SetActive(true);
	}
}