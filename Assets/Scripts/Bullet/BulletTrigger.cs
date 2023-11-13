using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
	[SerializeField] private BulletParameters bulletParameters;

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.root.TryGetComponent(out EnemyComponents enemyComponents))
		{
			transform.parent.gameObject.SetActive(false);
			foreach (var receiveDamage in enemyComponents.ComponentsReceiveDamage)
				receiveDamage.OnDamageReceive(bulletParameters.Damage);
		}
	}
}