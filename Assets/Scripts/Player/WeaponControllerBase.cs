using System;
using Inputs;
using UnityEngine;

public abstract class WeaponControllerBase : MonoBehaviour
{
	[SerializeField] protected BulletPool bulletPool;
	public event Action<float> CooledownTimeChanged;

	protected float TimerFromLastShoot;
	protected float BaseCooledDownTime = 1;
	public bool IsReadyToShoot => TimerFromLastShoot >= BaseCooledDownTime;

	protected abstract void TryFire(InputVariables input);

	protected virtual void Start()
	{
		TimerFromLastShoot = BaseCooledDownTime;

		var inputProvider = GetComponent<IInputProvider>();
		inputProvider.InputChanged += TryFire;
	}

	private void Update()
	{
		if (IsReadyToShoot)
			return;

		TimerFromLastShoot += Time.deltaTime;
		CooledownTimeChanged?.Invoke(BaseCooledDownTime - TimerFromLastShoot);
	}
}