using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
	[SerializeField] private Transform bulletOriginSpawnPoint;
	[SerializeField] private Vector3 offsetSpawnPoint;

	[SerializeField] private BulletMovement simpleBullet;
	[SerializeField] private Transform simpleBulletPoolContainer;

	private List<BulletMovement> _simpleBulletPool = new List<BulletMovement>();

	public void TakeBulletAndActivate()
	{
		var bullet = _simpleBulletPool.FirstOrDefault(x => !x.gameObject.activeSelf);

		if (bullet is null)
		{
			bullet = Instantiate(simpleBullet, simpleBulletPoolContainer);
			_simpleBulletPool.Add(bullet);
		}

		bullet.Activate(bulletOriginSpawnPoint.position + offsetSpawnPoint);
	}

	private void OnDrawGizmosSelected()
	{
		if (bulletOriginSpawnPoint == null)
			return;

		Gizmos.DrawSphere(bulletOriginSpawnPoint.position + offsetSpawnPoint, 0.5f);
	}
}