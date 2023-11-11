using UnityEngine;

namespace DefaultNamespace
{
	public class CubeExplosiveEffect : MonoBehaviour, IExplosiveEffect
	{
		[SerializeField] private DeathController cubeDeathController;

		public void Explode()
		{
			//Reduce player health
			GameManager.Instance.PlayerHealthController.ChangeHealth(-10);
			//Add others cubes 10% of health

			cubeDeathController.DeathExecution();
		}
	}
}