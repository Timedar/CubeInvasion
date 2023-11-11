using UnityEngine;

namespace DefaultNamespace
{
	public class CubeExplosiveEffect : MonoBehaviour, IExplosiveEffect
	{
		[SerializeField] private int damage;
		[SerializeField] private DeathController cubeDeathController;

		public void Explode()
		{
			//Reduce player health
			GameManager.Instance.PlayerHealthController.ChangeHealth(-damage);
			//Add others cubes 10% of health

			cubeDeathController.DeathExecution();
		}
	}
}