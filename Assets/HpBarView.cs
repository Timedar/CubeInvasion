using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarView : MonoBehaviour
{
	[SerializeField] private Image fillImage;
	private HealthController _playerHealthController;

	private void Start()
	{
		_playerHealthController = GameManager.Instance.PlayerHealthController;
		_playerHealthController.HealthChanged += OnHealthChanged;
	}

	private void OnHealthChanged(int value)
	{
		fillImage.fillAmount = (float)value / _playerHealthController.MaxHealth;
	}
}