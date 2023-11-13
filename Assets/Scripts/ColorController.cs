using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
	[SerializeField] private MeshRenderer meshRenderer;

	public void ChangeColor(Color color) => meshRenderer.material.color = color;
}