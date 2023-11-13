using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosive : MonoBehaviour, IExplosive
{
	public void ExecuteEffect()
	{
		Debug.Log("BOOM!");
		//Add points to manager
		GameManager.Instance.PointsManager.AddPoint(10);
		//Add exp for player
		GameManager.Instance.ExpManager.AddPoint(30);
	}
}