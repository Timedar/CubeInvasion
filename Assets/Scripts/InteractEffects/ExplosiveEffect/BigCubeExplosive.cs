using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class BigCubeExplosive : MonoBehaviour, IExplosive
{
	[SerializeField] private int damage;
	[SerializeField] private DeathController cubeDeathController;

	public void ExecuteEffect()
	{
		//Reduce player health
		GameManager.Instance.PlayerHealthController.ChangeHealth(-damage);
		//Add others cubes 10% of health
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