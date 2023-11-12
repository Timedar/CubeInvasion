using Movement;
using Movement.Enemy;
using UnityEngine;

[System.Serializable]
public struct EnemySpawnParameters
{
	public string name;
	[Range(0, 100)] public float spawnChance;
	public EnemyMovement enemyPrefab;
}