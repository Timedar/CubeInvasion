using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager
{
	public int points;
	public event Action<int> PointsChanged;

	public void AddPoint(int value)
	{
		points += value;
		PointsChanged?.Invoke(points);
	}
}

public class GameManager : MonoBehaviour
{
	[SerializeField] private HealthController playerHealthController;

	private readonly PointManager _pointManager = new PointManager();

	public static GameManager Instance;

	public HealthController PlayerHealthController => playerHealthController;

	private void Awake()
	{
		Instance = this;
	}
}