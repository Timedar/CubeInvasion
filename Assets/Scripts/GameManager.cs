using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class PointsBase
{
	private int _points;
	public event Action<int> PointsChanged;

	public void AddPoint(int value)
	{
		_points += value;
		PointsChanged?.Invoke(_points);
	}
}

public sealed class PointsManager : PointsBase
{
	public PointsManager()
	{
	}
}

public sealed class ExpManager : PointsBase
{
	private PlayerLevelData _currentLevel;
	private List<PlayerLevelData> _levelList;

	public event Action<PlayerLevelData> LevelUp;

	public ExpManager(List<PlayerLevelData> playerLevelDatas)
	{
		_levelList = playerLevelDatas;
		_currentLevel = _levelList[0];

		PointsChanged += TryLevelUp;
	}

	public void TryLevelUp(int value)
	{
		//If value is bigger than x lvlup
		if (value < _currentLevel.RequireExperienceForNextLevel)
			return;

		var nextLevelIndex = _levelList.IndexOf(_currentLevel) + 1;
		_currentLevel = _levelList[nextLevelIndex];

		Debug.Log("!!!LEVEL UP!!!");
		LevelUp?.Invoke(_currentLevel);
	}
}

public class GameManager : MonoBehaviour
{
	[SerializeField] private HealthController playerHealthController;
	[SerializeField] private List<PlayerLevelData> playerLevelDatas;

	private PointsManager _pointsManager;
	private ExpManager _expExpManager;

	public static GameManager Instance;

	public PointsManager PointsManager => _pointsManager;
	public ExpManager ExpManager => _expExpManager;
	public HealthController PlayerHealthController => playerHealthController;

	public event Action EndGame;


	private void Awake()
	{
		Instance = this;

		Assert.IsNotNull(playerLevelDatas, "Player levels are not loaded!");

		_pointsManager = new PointsManager();
		_expExpManager = new ExpManager(playerLevelDatas);
	}

	private void Start()
	{
		playerHealthController.HealthChanged += HandleEndGame;
	}

	private void HandleEndGame(int playerHpPoints)
	{
		if (playerHpPoints > 0)
			return;

		PauseGame();

		EndGame?.Invoke();
	}

	private static void PauseGame() => Time.timeScale = 0;
}