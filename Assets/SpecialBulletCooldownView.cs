using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpecialBulletCooldownView : MonoBehaviour
{
	[SerializeField] private PlayerWeaponController _weaponController;
	[SerializeField] private TextMeshProUGUI _textMeshProUGUI;

	private string timerText;

	private void Start()
	{
		timerText = _textMeshProUGUI.text;
		_weaponController.CooledownTimeChanged += HandleTimerChanged;
	}

	private void HandleTimerChanged(float value)
	{
		var suffix = value > 0.1f ? value.ToString("F1") : "Ready!";
		_textMeshProUGUI.text = timerText + suffix;
	}
}