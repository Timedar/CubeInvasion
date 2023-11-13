using System;
using System.Collections;
using System.Threading;
using Inputs;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerWeaponController : MonoBehaviour
{
	[SerializeField] private BulletPool bulletPool;
	[SerializeField] private BulletPool specialBulletPool;
	[SerializeField, Range(0, 2)] private float cooledDownTime = 1;

	private float _timerFromLastShoot;
	private bool IsReadyToShoot => _timerFromLastShoot >= cooledDownTime;

	private PlayerLevelData currentPlayerLevelData;

	private void Start()
	{
		_timerFromLastShoot = cooledDownTime;

		GameManager.Instance.ExpManager.LevelUp += HandleNewPlayerLevelData;

		var inputProvider = GetComponent<IInputProvider>();
		inputProvider.InputChanged += TryFireSimpleBullet;
		inputProvider.InputChanged += FireSpecialBullet;
	}

	private void HandleNewPlayerLevelData(PlayerLevelData newLevelData)
	{
		currentPlayerLevelData = newLevelData;
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
		if (input.AttackInput && IsReadyToShoot)
		{
			bulletPool.TakeBulletAndActivate();
			_timerFromLastShoot = 0;
		}
	}

	private void Update()
	{
		if (!IsReadyToShoot)
			_timerFromLastShoot += Time.deltaTime;
	}
}