using System;
using System.Collections;
using System.Collections.Generic;
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

	private static List<EnemyComponents> _spawnedEnemies = new List<EnemyComponents>();
	private Bounds _colliderBounds;
	private float _currentTimer;

	public static List<EnemyComponents> SpawnedEnemies => _spawnedEnemies;

	private void Start()
	{
		_colliderBounds = GetComponent<BoxCollider>().bounds;
	}

	public EnemyComponents SelectEnemyToSpawn()
	{
		var rolledChance = Random.Range(0, 100f);

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

	public EnemyComponents SpawnEnemy(EnemyComponents enemyMovement)
	{
		var position = new Vector3(
			Random.Range(_colliderBounds.min.x, _colliderBounds.max.x),
			0f,
			_colliderBounds.center.z);

		return Instantiate(enemyMovement, position, Quaternion.identity);
	}

	private void TryToSpawnEnemy()
	{
		if (_currentTimer < enemyFactoryData.SpawningRate)
			return;

		var enemyPrefabToSpawn = SelectEnemyToSpawn();
		var spawnedEnemy = SpawnEnemy(enemyPrefabToSpawn);

		spawnedEnemy.ColorController.ChangeColor(Random.ColorHSV());
		MenageSpawnedEnemies(spawnedEnemy);

		_currentTimer = 0;
	}

	private void MenageSpawnedEnemies(EnemyComponents spawnedEnemy)
	{
		SpawnedEnemies.Add(spawnedEnemy);
		spawnedEnemy.DeathController.MarkedAsDead += () => HandleEnemyDeath(spawnedEnemy);
	}

	private void HandleEnemyDeath(EnemyComponents spawnedEnemy)
	{
		SpawnedEnemies.Remove(spawnedEnemy);
		spawnedEnemy.DeathController.Destory();
	}

	private void Update()
	{
		_currentTimer += Time.deltaTime;

		TryToSpawnEnemy();
	}
}