using System;
using System.Collections;
using System.Threading;
using Inputs;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerWeaponController : MonoBehaviour
{
	[SerializeField] private BulletPool bulletPool;
	[SerializeField, Range(0, 2)] private float cooledDownTime = 1;

	private float _timerFromLastShoot;
	private bool IsReadyToShoot => _timerFromLastShoot >= cooledDownTime;


	private void Start()
	{
		_timerFromLastShoot = cooledDownTime;

		var inputProvider = GetComponent<IInputProvider>();
		inputProvider.InputChanged += TryFireSimpleBullet;
		inputProvider.InputChanged += FireSpecialBullet;
	}

	private void TryFireSimpleBullet(InputVariables input)
	{
		if (input.AttackInput && IsReadyToShoot)
		{
			bulletPool.TakeBulletAndActivate();
			_timerFromLastShoot = 0;
		}
	}

	private void FireSpecialBullet(InputVariables input)
	{
		// if (input.SpecialAttackInput && IsReadyToShoot)
	}

	private void Update()
	{
		if (!IsReadyToShoot)
			_timerFromLastShoot += Time.deltaTime;
	}
}