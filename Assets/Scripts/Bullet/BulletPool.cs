using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletPool : MonoBehaviour
{
	[SerializeField] private Transform bulletOriginSpawnPoint;
	[SerializeField] private Vector3 offsetSpawnPoint;

	[SerializeField] private BulletMovement bullet;

	private List<BulletMovement> _simpleBulletPool = new List<BulletMovement>();

	public GameObject TakeBulletAndActivate()
	{
		var bullet = _simpleBulletPool.FirstOrDefault(x => !x.gameObject.activeSelf);

		if (bullet is null)
		{
			bullet = Instantiate(this.bullet, transform);
			_simpleBulletPool.Add(bullet);
		}

		bullet.Activate(bulletOriginSpawnPoint.position + offsetSpawnPoint);
		return bullet.gameObject;
	}

	private void OnDrawGizmosSelected()
	{
		if (bulletOriginSpawnPoint == null)
			return;

		Gizmos.DrawSphere(bulletOriginSpawnPoint.position + offsetSpawnPoint, 0.5f);
	}
}