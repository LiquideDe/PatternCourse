using System;
using System.Collections.Generic;

public abstract class VictoryCondition
{
    protected List<int> _amountCirclesByType;
    protected List<int> _amountMaxCirclesByType;

    public event Action GameWining;
    public event Action GameLoose;

    public void SetCircles(List<int> amountCirclesByType)
    {
        _amountCirclesByType = new List<int>(amountCirclesByType);
        _amountMaxCirclesByType = new List<int>(amountCirclesByType);
    }

    public void CircleDown(TypeCircle typeCircle)
    {
        _amountCirclesByType[(int)typeCircle]--;
        CheckCondition();
    }

    public virtual void RestartLevel()
    {
        _amountCirclesByType = new List<int>(_amountMaxCirclesByType);
    }

    protected abstract void CheckCondition();

    protected void Win() => GameWining?.Invoke();

    protected void Loose() => GameLoose?.Invoke();
}
