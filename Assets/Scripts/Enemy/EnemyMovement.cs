using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Movement.Enemy
{
	public class EnemyMovement : MonoBehaviour
	{
		[SerializeField] private MovementData movementData;

		private Movement _movement;
		private float _actualSpeedModifier = 0;

		public void ModifyActualMovementSpeed(float value) => _actualSpeedModifier += value;

		private void Start()
		{
			_movement = new Movement(transform);
		}

		private void Update()
		{
			_movement.Move(new Vector3(0, 0, -1), movementData.MovementSpeed() * (1 - _actualSpeedModifier));
		}
	}
}