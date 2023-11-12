using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CubeInvasion/EnemySpawnerData", fileName = "EnemySpawnerData", order = 0)]
public class EnemyFactoryData : ScriptableObject
{
	[SerializeField] private float spawningRate;
	[SerializeField] private List<EnemySpawnParameters> enemySpawnParametersList;

	public float SpawningRate => spawningRate;
	public List<EnemySpawnParameters> EnemySpawnParametersList => enemySpawnParametersList;
}