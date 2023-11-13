using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class SpecialBulletCooldownView : MonoBehaviour
{
	[SerializeField] private PlayerSpecialWeaponController weaponController;
	[SerializeField] private TextMeshProUGUI textMeshProUGUI;

	private string _timerText;

	private void Start()
	{
		_timerText = textMeshProUGUI.text;
		weaponController.CooledownTimeChanged += HandleTimerChanged;
	}

	private void HandleTimerChanged(float value)
	{
		var suffix = value > 0.1f ? value.ToString("F1") : "Ready!";
		textMeshProUGUI.text = _timerText + suffix;
	}
}