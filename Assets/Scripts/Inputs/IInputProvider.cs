using System;

namespace Inputs
{
	public interface IInputProvider
	{
		public event Action<InputVariables> InputChanged;
	}
}