using System.Collections;
using System.Threading;
using Inputs;
using UnityEngine;
using UnityEngine.Serialization;

public sealed class PlayerWeaponController : WeaponControllerBase
{
	[SerializeField, Range(0, 2)] private float cooledDown = 1;

	protected override void Start()
	{
		base.Start();
		BaseCooledDownTime = cooledDown;
	}

	protected override void TryFire(InputVariables input)
	{
		if (input.AttackInput && IsReadyToShoot)
		{
			bulletPool.TakeBulletAndActivate();
			TimerFromLastShoot = 0;
		}
	}
}