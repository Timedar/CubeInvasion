using UnityEngine;

namespace Movement
{
	[CreateAssetMenu(menuName = "CubeInvasion/Movement/Simple MovementData", fileName = "Simple MovementData", order = 0)]
	public class SimpleMovementData : MovementData
	{
		[SerializeField] private float movementSpeed = 10;

		public override float MovementSpeed()
		{
			return movementSpeed;
		}
	}
}