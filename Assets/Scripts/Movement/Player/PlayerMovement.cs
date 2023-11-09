using Inputs;
using UnityEngine;

namespace Movement.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private MovementData movementData;

		private Movement _movement;

		private void Start()
		{
			_movement = new Movement(transform);

			if (TryGetComponent(out IInputProvider inputProvider))
				inputProvider.InputChanged += HandleMovement;
		}

		private void HandleMovement(InputVariables input)
		{
			_movement.Move(new Vector3(input.HorizontalInput, 0, 0), movementData.MovementSpeed);
		}
	}
}