using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

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
	private static void ResumeGame() => Time.timeScale = 1;

	private void OnDisable()
	{
		ResumeGame();
	}
}