using System;
using UnityEngine;

namespace Inputs
{
	public class InputSystem : MonoBehaviour, IInputProvider
	{
		private InputVariables _inputVariables;

		private void Update()
		{
			_inputVariables.HorizontalInput = Input.GetAxis("Horizontal");
			_inputVariables.AttackInput = Input.GetButton("Fire1");
			_inputVariables.SpecialAttackInput = Input.GetButtonDown("Fire2");

			InputChanged?.Invoke(_inputVariables);
		}

		public event Action<InputVariables> InputChanged;
	}
}