using System;
using System.Collections;
using System.Collections.Generic;
using Movement.Enemy;
using TMPro;
using UnityEngine;

public class SpeedView : MonoBehaviour
{
	[SerializeField] private EnemyMovement enemyMovement;
	[SerializeField] private TextMeshProUGUI _textMeshProUGUI;

	private void Update()
	{
		_textMeshProUGUI.text = enemyMovement.Speed.ToString();
	}
}