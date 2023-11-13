using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedlineTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.root.TryGetComponent(out EnemyComponents enemyComponents))
			foreach (var readLineExplosive in enemyComponents?.RedLineExplosives)
				readLineExplosive.ExecuteEffect();
	}
}