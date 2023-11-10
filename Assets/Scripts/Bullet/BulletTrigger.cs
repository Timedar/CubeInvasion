using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
	private IExplosiveEffect _explosiveEffect;

	private void Start()
	{
		var root = transform.parent;

		_explosiveEffect = root.GetComponent<IExplosiveEffect>();
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log($"Bullet Detected: {other.name}");
		if (other.transform.root.TryGetComponent(out HealthController healthController))
		{
			//Reduce enemy health by predefine damage
			var enemyHealth = healthController.ChangeHealth(-10);

			if (enemyHealth <= 0)
				_explosiveEffect.Explode();

			transform.parent.gameObject.SetActive(false);
		}
	}
}