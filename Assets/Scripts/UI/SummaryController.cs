using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class SummaryController : MonoBehaviour
{
	[SerializeField] private CanvasGroupController canvasGroupController;

	private void Start()
	{
		GameManager.Instance.EndGame += () => canvasGroupController.ChangeVisibilityOfSummaryPanel(true);
	}
}