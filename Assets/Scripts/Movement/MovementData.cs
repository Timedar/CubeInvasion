using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
	[CreateAssetMenu(menuName = "CubeInvasion/MovementData", fileName = "MovementData", order = 0)]
	public class MovementData : ScriptableObject
	{
		[SerializeField] private float movementSpeed = 10;

		public float MovementSpeed => movementSpeed;
	}
}