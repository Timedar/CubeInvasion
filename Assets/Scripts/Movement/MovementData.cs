using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
	public abstract class MovementData : ScriptableObject
	{
		public abstract float MovementSpeed();
	}
}