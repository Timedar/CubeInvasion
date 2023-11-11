using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpiriencePanelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsTextMesh;

    private void Start()
    {
        GameManager.Instance.ExpManager.PointsChanged += OnPointsChanged;
    }

    private void OnPointsChanged(int value)
    {
        pointsTextMesh.text = value.ToString();
    }
}
