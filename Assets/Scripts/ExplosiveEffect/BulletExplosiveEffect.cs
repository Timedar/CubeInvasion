using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosiveEffect : MonoBehaviour, IExplosiveEffect
{
	public void Explode()
	{
		Debug.Log("BOOM!");
		//Add points to manager
		//Add exp for player
	}
}