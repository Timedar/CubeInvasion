using UnityEngine;

public class CanvasGroupController : MonoBehaviour
{
	[SerializeField] private CanvasGroup summaryPanelCanvasGroup;

	public void ChangeVisibilityOfSummaryPanel(bool value)
	{
		summaryPanelCanvasGroup.alpha = value ? 1 : 0;
		summaryPanelCanvasGroup.interactable = value;
		summaryPanelCanvasGroup.blocksRaycasts = value;
	}
}