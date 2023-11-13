using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletExplosive : MonoBehaviour, IExplosive
{
	[SerializeField] private float radius = 2f;
	[SerializeField] private GameObject explodeVfx;
	[SerializeField] private BulletMovement bulletMovement;
	[SerializeField] private Collider bulletCollider;
	[SerializeField] private BulletParameters bulletParameters;

	public void ExecuteEffect()
	{
		TryGetEnemiesAround();

		bulletCollider.enabled = false;
		bulletMovement.StopMovement();
		explodeVfx.SetActive(true);
		Invoke(nameof(Disable), 0.5f);
	}

	private void TryGetEnemiesAround()
	{
		var colliders = Physics.OverlapSphere(this.transform.position, radius);

		foreach (var colider in colliders)
		{
			if (colider.transform.root.TryGetComponent(out EnemyComponents enemyComponents))
			{
				foreach (var damageReciever in enemyComponents.ComponentsReceiveDamage)
				{
					damageReciever.OnDamageReceive(bulletParameters.Damage);
				}
			}
		}
	}

	private void Disable()
	{
		this.gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		CancelInvoke();
		explodeVfx.SetActive(false);
		bulletCollider.enabled = true;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(this.transform.position, radius);
	}
}