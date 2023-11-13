using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletParameters : MonoBehaviour
{
	private PlayerLevelData _currentLevel;

	public int Damage => _currentLevel.SimpleBulletDamage;

	private void Start()
	{
		_currentLevel = GameManager.Instance.ExpManager.CurrentLevel;

		GameManager.Instance.ExpManager.LevelUp += (newlevelData) => _currentLevel = newlevelData;
	}
}