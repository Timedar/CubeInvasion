using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI pointsTextMesh;

	private void Start()
	{
		GameManager.Instance.PointsManager.PointsChanged += OnPointsChanged;
	}

	private void OnPointsChanged(int value)
	{
		pointsTextMesh.text = value.ToString();
	}
}