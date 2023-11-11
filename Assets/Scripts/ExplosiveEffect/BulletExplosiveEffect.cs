using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosiveEffect : MonoBehaviour, IExplosiveEffect
{
	public void Explode()
	{
		Debug.Log("BOOM!");
		//Add points to manager
		GameManager.Instance.PointsManager.AddPoint(10);
		//Add exp for player
		GameManager.Instance.ExpManager.AddPoint(30);
	}
}