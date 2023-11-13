using Inputs;

namespace Player
{
	public class PlayerSpecialWeaponController : PlayerWeaponController
	{
		protected override void HandleNewPlayerLevelData(PlayerLevelData newLevelData)
		{
			cooledDownTime = newLevelData.SpecialBulletCooldown;
		}

		protected override void TryFire(InputVariables input)
		{
			if (input.SpecialAttackInput && IsReadyToShoot)
			{
				bulletPool.TakeBulletAndActivate();
				_timerFromLastShoot = 0;
			}
		}
	}
}