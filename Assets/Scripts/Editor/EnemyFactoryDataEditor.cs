using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyFactoryData))]
public class EnemyFactoryDataEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		EnemyFactoryData enemyFactoryData = (EnemyFactoryData)target;

		float sum = 0f;
		foreach (EnemySpawnParameters parameters in enemyFactoryData.EnemySpawnParametersList)
			sum += parameters.spawnChance;

		if (sum != 100f)
			EditorGUILayout.HelpBox("The sum of parameters must be exactly 100!", MessageType.Warning);
	}
}