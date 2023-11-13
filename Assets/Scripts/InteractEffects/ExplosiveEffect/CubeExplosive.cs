using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
	public class CubeExplosive : MonoBehaviour, IRedLineExplosive
	{
		[SerializeField] private DeathController cubeDeathController;

		public void ExecuteEffect()
		{
			var selectedEnemies =
				EnemyFactory.SpawnedEnemies.Where(x => x.EnemyType is EnemyType.Cube or EnemyType.BigCube);

			foreach (var enemy in selectedEnemies)
			{
				var enemyHealthController = enemy.HealthController;
				enemyHealthController.ChangeHealth(Mathf.CeilToInt(enemyHealthController.MaxHealth * 0.1f));
			}

			cubeDeathController.MarkAsDead();
		}
	}
}