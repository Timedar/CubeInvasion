using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ExplosiveDamage : MonoBehaviour, IRedLineExplosive
{
	[SerializeField] private int damage;
	[SerializeField] private DeathController cubeDeathController;

	public void ExecuteEffect()
	{
		GameManager.Instance.PlayerHealthController.ChangeHealth(-damage);
		cubeDeathController.MarkAsDead();
	}
}