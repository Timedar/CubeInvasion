using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "CubeInvasion/Player/PlayerLevelData", fileName = "PlayerLevelData", order = 0)]
public class PlayerLevelData : ScriptableObject
{
	[SerializeField] private int simpleBulletDamage = 10;
	[SerializeField] private float specialBulletCooldown = 5;
	[SerializeField] private int requireExperienceForNextLevel = 30;

	public int SimpleBulletDamage => simpleBulletDamage;
	public float SpecialBulletCooldown => specialBulletCooldown;

	public int RequireExperienceForNextLevel => requireExperienceForNextLevel;
}