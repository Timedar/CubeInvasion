using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummaryController : MonoBehaviour
{
	[SerializeField] private CanvasGroup summaryPanelCanvasGroup;

	private void Start()
	{
		GameManager.Instance.PlayerHealthController.HealthChanged += EndGameHandler;
	}

	private void EndGameHandler(int hpValue)
	{
		if (hpValue > 0)
			return;

		ChangeVisibilityOfSummaryPanel(true);
	}

	private void ChangeVisibilityOfSummaryPanel(bool value)
	{
		summaryPanelCanvasGroup.alpha = value ? 1 : 0;
		summaryPanelCanvasGroup.interactable = value;
		summaryPanelCanvasGroup.blocksRaycasts = value;
	}
}