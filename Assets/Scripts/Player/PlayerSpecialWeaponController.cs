using Inputs;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
	public sealed class PlayerSpecialWeaponController : WeaponControllerBase
	{
		private GameObject _cashedBullet;

		protected override void Start()
		{
			base.Start();
			
			TimerFromLastShoot = GameManager.Instance.ExpManager.CurrentLevel.SpecialBulletCooldown;
			HandleNewPlayerLevelData(GameManager.Instance.ExpManager.CurrentLevel);
			GameManager.Instance.ExpManager.LevelUp += HandleNewPlayerLevelData;
		}

		private void HandleNewPlayerLevelData(PlayerLevelData newLevelData)
		{
			BaseCooledDownTime = newLevelData.SpecialBulletCooldown;
		}

		protected override void TryFire(InputVariables input)
		{
			if (_cashedBullet != null && _cashedBullet.activeSelf && input.SpecialAttackInput)
			{
				DetonateBullet();
			}
			else if (input.SpecialAttackInput && IsReadyToShoot)
			{
				_cashedBullet = bulletPool.TakeBulletAndActivate();
				TimerFromLastShoot = 0;
			}
		}

		private void DetonateBullet()
		{
			if (_cashedBullet.TryGetComponent(out IExplosive explosive))
				explosive.ExecuteEffect();
		}
	}
}