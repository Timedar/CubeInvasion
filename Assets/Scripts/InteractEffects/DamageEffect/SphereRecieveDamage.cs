using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SphereReceiveDamage : MonoBehaviour, IReceiveDamage
{
	[SerializeField, Range(0, 100)] private float additionalSpeedAfterDamagePercentage = 10;

	public void OnDamageReceive(int damage)
	{
		var selectedEnemies =
			EnemyFactory.SpawnedEnemies.Where(x => x.EnemyType is EnemyType.Sphere);

		foreach (var enemy in selectedEnemies)
		{
			var enemyHealthController = enemy.EnemyMovement;
			enemyHealthController.ModifyActualMovementSpeed(additionalSpeedAfterDamagePercentage / 100);
		}
	}
}