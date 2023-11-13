using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummaryController : MonoBehaviour
{
	[SerializeField] private CanvasGroupController canvasGroupController;

	[UsedImplicitly]
	public void ReloadScene() => SceneManager.LoadScene(0);

	[UsedImplicitly]
	public void QuickGame() => Application.Quit();

	private void Start()
	{
		GameManager.Instance.EndGame += () => canvasGroupController.ChangeVisibilityOfSummaryPanel(true);
	}
}