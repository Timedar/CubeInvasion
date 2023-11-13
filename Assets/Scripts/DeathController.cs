using System;
using UnityEngine;

namespace DefaultNamespace
{
	public class DeathController : MonoBehaviour
	{
		public event Action MarkedAsDead;

		private void Start()
		{
			if (TryGetComponent(out HealthController healthController))
			{
				healthController.HealthChanged += (value) =>
				{
					if (value <= 0)
						MarkAsDead();
				};
			}
		}

		public void MarkAsDead()
		{
			MarkedAsDead?.Invoke();
		}

		public void Destory()
		{
			Destroy(gameObject);
		}
	}
}