using DefaultNamespace;
using Movement;
using Movement.Enemy;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(ColorController))]
[RequireComponent(typeof(DeathController))]
[RequireComponent(typeof(HealthController))]
public class EnemyComponents : MonoBehaviour
{
	[SerializeField] private EnemyType enemyType;
	[SerializeField] private int expForEnemy = 10;
	[SerializeField] private int pointsForEnemy = 1;

	private EnemyMovement _enemyMovement;
	private HealthController _healthHealthController;
	private DeathController _deathController;
	private ColorController _colorController;
	private IExplosive[] _explosives;
	private IReceiveDamage[] _componentsReceiveDamage;
	private IRedLineExplosive[] _redLineExplosives;
	public EnemyMovement EnemyMovement => _enemyMovement;
	public HealthController HealthController => _healthHealthController;
	public DeathController DeathController => _deathController;
	public ColorController ColorController => _colorController;
	public IExplosive[] Explosives => _explosives;
	public EnemyType EnemyType => enemyType;
	public IReceiveDamage[] ComponentsReceiveDamage => _componentsReceiveDamage;
	public int ExpForEnemy => expForEnemy;
	public int PointsForEnemy => pointsForEnemy;
	public IRedLineExplosive[] RedLineExplosives => _redLineExplosives;

	private void Awake()
	{
		_enemyMovement = GetComponent<EnemyMovement>();
		_colorController = GetComponent<ColorController>();
		_deathController = GetComponent<DeathController>();
		_healthHealthController = GetComponent<HealthController>();
		_explosives = GetComponents<IExplosive>();
		_componentsReceiveDamage = GetComponents<IReceiveDamage>();
		_redLineExplosives = GetComponents<IRedLineExplosive>();
	}
}