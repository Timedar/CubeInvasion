using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour, IReceiveDamage
{
	private HealthController _healthController;

	private void Awake()
	{
		_healthController = GetComponent<HealthController>();
	}

	public void OnDamageReceive(int damage)
	{
		_healthController.ChangeHealth(-damage);
	}
}