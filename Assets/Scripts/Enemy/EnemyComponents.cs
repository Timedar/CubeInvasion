using DefaultNamespace;
using Movement;
using Movement.Enemy;
using UnityEngine;

[RequireComponent(typeof(ColorController))]
[RequireComponent(typeof(DeathController))]
[RequireComponent(typeof(HealthController))]
public class EnemyComponents : MonoBehaviour
{
	[SerializeField] private EnemyType enemyType;

	private EnemyMovement _enemyMovement;
	private HealthController _healthHealthController;
	private DeathController _deathController;
	private ColorController _colorController;
	private IExplosive _explosive;
	private IReceiveDamage[] _componentsReceiveDamage;

	public EnemyMovement EnemyMovement => _enemyMovement;
	public HealthController HealthController => _healthHealthController;
	public DeathController DeathController => _deathController;
	public ColorController ColorController => _colorController;
	public IExplosive Explosive => _explosive;

	public EnemyType EnemyType => enemyType;

	public IReceiveDamage[] ComponentsReceiveDamage => _componentsReceiveDamage;

	private void Awake()
	{
		_enemyMovement = GetComponent<EnemyMovement>();
		_colorController = GetComponent<ColorController>();
		_deathController = GetComponent<DeathController>();
		_healthHealthController = GetComponent<HealthController>();
		_explosive = GetComponent<IExplosive>();
		_componentsReceiveDamage = GetComponents<IReceiveDamage>();
	}
}