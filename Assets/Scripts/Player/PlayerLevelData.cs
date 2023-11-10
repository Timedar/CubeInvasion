using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CubeInvasion/Player/PlayerLevelData", fileName = "PlayerLevelData", order = 0)]
public class PlayerLevelData : ScriptableObject
{
	[SerializeField] private int simpleBulletDamage = 10;
	[SerializeField] private float specialBulletCooldown = 5;

	public int SimpleBulletDamage => simpleBulletDamage;
	public float SpecialBulletCooldown => specialBulletCooldown;
}