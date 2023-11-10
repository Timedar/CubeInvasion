using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
	[SerializeField] private int initHealth = 10;

	private int _health;

	public int ActualHealth => _health;
	public event Action<int> HealthChanged;

	public int ChangeHealth(int value)
	{
		_health += value;
		HealthChanged?.Invoke(_health);
		return _health;
	}

	private void Start()
	{
		_health = initHealth;
	}
}