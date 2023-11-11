using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HudController : MonoBehaviour
{
	[SerializeField] private CanvasGroupController canvasGroupController;

	private void Start()
	{
		GameManager.Instance.EndGame += () => canvasGroupController.ChangeVisibilityOfSummaryPanel(false);
	}
}