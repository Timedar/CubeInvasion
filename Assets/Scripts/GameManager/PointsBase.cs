using System;

public abstract class PointsBase
{
	private int _points;
	public event Action<int> PointsChanged;

	public void AddPoint(int value)
	{
		_points += value;
		PointsChanged?.Invoke(_points);
	}
}