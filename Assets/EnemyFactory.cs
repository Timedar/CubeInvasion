using System;
using System.Collections;
using System.Linq;
using System.Threading;
using JetBrains.Annotations;
using Movement;
using Movement.Enemy;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]
public class EnemyFactory : MonoBehaviour
{
	[SerializeField] private EnemyFactoryData enemyFactoryData;

	private Bounds colliderBounds;
	private float currentTimer;

	private void Start()
	{
		colliderBounds = GetComponent<BoxCollider>().bounds;
	}

	public EnemyMovement SelectEnemyToSpawn()
	{
		var rolledChance = UnityEngine.Random.Range(0, 100f);

		var orderedRarityList = enemyFactoryData.EnemySpawnParametersList.OrderBy(x => x.spawnChance);

		float calculatedRarity = 0;
		EnemySpawnParameters? selectedParameter = null;

		foreach (var parameter in orderedRarityList)
		{
			calculatedRarity += parameter.spawnChance;

			if (rolledChance <= calculatedRarity)
			{
				selectedParameter = parameter;
				break;
			}
		}

		return selectedParameter?.enemyPrefab;
	}

	public void SpawnEnemy(EnemyMovement enemyMovement)
	{
		var position = new Vector3(
			Random.Range(colliderBounds.min.x, colliderBounds.max.x),
			0f,
			colliderBounds.center.z);

		Instantiate(enemyMovement, position, Quaternion.identity);
	}

	private void TryToSpawnEnemy()
	{
		if (currentTimer < enemyFactoryData.SpawningRate)
			return;

		var enemyPrefabToSpawn = SelectEnemyToSpawn();
		SpawnEnemy(enemyPrefabToSpawn);

		currentTimer = 0;
	}

	private void Update()
	{
		currentTimer += Time.deltaTime;

		TryToSpawnEnemy();
	}
}