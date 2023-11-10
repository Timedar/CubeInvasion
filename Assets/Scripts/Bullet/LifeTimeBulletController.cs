using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeBulletController : MonoBehaviour
{
	[SerializeField] private float lifeTime = 5;

	private void OnEnable()
	{
		Invoke(nameof(TurnOfBullet), lifeTime);
	}

	private void OnDisable()
	{
		CancelInvoke();
	}

	private void TurnOfBullet() => gameObject.SetActive(false);
}