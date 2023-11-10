using System;
using UnityEngine;

namespace DefaultNamespace
{
	public class DeathController : MonoBehaviour
	{
		private void Start()
		{
			if (TryGetComponent(out HealthController healthController))
			{
				healthController.HealthChanged += (value) =>
				{
					if (value <= 0)
						DeathExecution();
				};
			}
		}

		public void DeathExecution()
		{
			Destroy(gameObject);
		}
	}
}