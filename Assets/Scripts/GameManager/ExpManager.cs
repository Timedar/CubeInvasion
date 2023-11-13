using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class ExpManager : PointsBase
{
	private PlayerLevelData _currentLevel;
	private List<PlayerLevelData> _levelList;

	public PlayerLevelData CurrentLevel => _currentLevel;
	public event Action<PlayerLevelData> LevelUp;

	public ExpManager(List<PlayerLevelData> playerLevelDatas)
	{
		_levelList = playerLevelDatas;
		_currentLevel = _levelList[0];

		PointsChanged += TryLevelUp;
	}

	public void TryLevelUp(int value)
	{
		if (value < CurrentLevel.RequireExperienceForNextLevel)
			return;

		var nextLevelIndex = _levelList.IndexOf(CurrentLevel) + 1;

		if (nextLevelIndex > _levelList.Count - 1)
		{
			Debug.Log("Player reach max level!");
			return;
		}

		_currentLevel = _levelList[nextLevelIndex];


		LevelUp?.Invoke(CurrentLevel);
	}
}