using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedlineTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log($"Detected: {other.name}");
		if (other.transform.root.TryGetComponent(out IExplosiveEffect enemyExplosiveEffect))
			enemyExplosiveEffect.Explode();
	}
}