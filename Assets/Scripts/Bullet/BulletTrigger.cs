using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
	private int damage = 10;
	private IExplosive _explosive;

	private void Start()
	{
		var root = transform.parent;

		_explosive = root.GetComponent<IExplosive>();
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log($"Bullet Detected: {other.name}");
		transform.parent.gameObject.SetActive(false);

		if (other.transform.root.TryGetComponent(out EnemyComponents enemyComponents))
		{
			foreach (var receiveDamage in enemyComponents.ComponentsReceiveDamage)
				receiveDamage.OnDamageReceive(damage);
		}
	}
}