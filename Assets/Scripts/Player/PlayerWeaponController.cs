using System;
using System.Collections;
using System.Threading;
using Inputs;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerWeaponController : MonoBehaviour
{
	[SerializeField] protected BulletPool bulletPool;
	[SerializeField, Range(0, 2)] protected float cooledDownTime = 1;

	protected float _timerFromLastShoot;
	public bool IsReadyToShoot => _timerFromLastShoot >= cooledDownTime;

	public event Action<float> CooledownTimeChanged;

	private void Start()
	{
		_timerFromLastShoot = cooledDownTime;

		GameManager.Instance.ExpManager.LevelUp += HandleNewPlayerLevelData;

		var inputProvider = GetComponent<IInputProvider>();
		inputProvider.InputChanged += TryFire;
	}

	protected virtual void HandleNewPlayerLevelData(PlayerLevelData newLevelData)
	{
	}

	protected virtual void TryFire(InputVariables input)
	{
		if (input.AttackInput && IsReadyToShoot)
		{
			bulletPool.TakeBulletAndActivate();
			_timerFromLastShoot = 0;
		}
	}

	private void Update()
	{
		if (IsReadyToShoot)
			return;

		_timerFromLastShoot += Time.deltaTime;
		CooledownTimeChanged?.Invoke(cooledDownTime - _timerFromLastShoot);
	}
}