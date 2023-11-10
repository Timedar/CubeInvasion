using Inputs;
using Movement;
using UnityEngine;

namespace Player
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private MovementData movementData;

		private Movement.Movement _movement;

		private void Start()
		{
			_movement = new Movement.Movement(transform);

			if (TryGetComponent(out IInputProvider inputProvider))
				inputProvider.InputChanged += HandleMovement;
		}

		private void HandleMovement(InputVariables input)
		{
			_movement.Move(new Vector3(input.HorizontalInput, 0, 0), movementData.MovementSpeed());
		}
	}
}