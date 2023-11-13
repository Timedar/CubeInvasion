using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class BigCubeExplosive : MonoBehaviour, IExplosive
{
	[SerializeField] private DeathController cubeDeathController;

	public void ExecuteEffect()
	{
		var selectedEnemies =
			EnemyFactory.SpawnedEnemies.Where(x =>
				x.HealthController.ActualHealth < (x.HealthController.MaxHealth / 2));

		foreach (var enemy in selectedEnemies)
		{
			var enemyHealthController = enemy.HealthController;
			enemyHealthController.ChangeHealth(Mathf.CeilToInt(enemyHealthController.MaxHealth / 2));
		}

		cubeDeathController.MarkAsDead();
	}
}