using UnityEngine;

namespace Movement
{
	[CreateAssetMenu(menuName = "CubeInvasion/Movement/Ratio MovementData", fileName = "Ratio MovementData", order = 0)]
	public class RatioMovementData : MovementData
	{
		[SerializeField] private SimpleMovementData simpleMovementData;
		[SerializeField, Range(0, 200)] private float movementSpeedRatio = 100;

		public override float MovementSpeed()
		{
			return simpleMovementData.MovementSpeed() * movementSpeedRatio / 100;
		}
	}
}