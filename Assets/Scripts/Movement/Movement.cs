using UnityEngine;

namespace Movement
{
	public class Movement
	{
		private readonly Transform _transform;

		private float scaller = 0.5f;

		public Movement(Transform transform)
		{
			_transform = transform;
		}

		public void Move(Vector3 move, float movementSpeed)
		{
			var position = _transform.position;
			position += move * (movementSpeed * Time.deltaTime);
			_transform.position = Vector3.Lerp(_transform.position, position, scaller);
		}
	}
}