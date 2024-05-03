using System;
using UnityEngine;

public class StayAtWorkState : MovementOrNotState
{
    public StayAtWorkState(BusinessCube businessCube, IStateSwitcher stateSwitcher) : base(businessCube, stateSwitcher)
    {
        _nameOfPoint = PointsOfInterestForBusinessCube.NamesOfPoint.None;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"Работаем");
        //Устали, отнимает четверть от скорости
        _businessCube.Speed = MinusQuarterOfNumber(BusinessCube.MaxSpeed);
        var timer = new System.Threading.Timer(TimeIsPassed, null, TimeSpan.FromSeconds(3), TimeSpan.Zero);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void ReachPoint()
    {
        StateSwitcher.SwitchState<MoveToHomeState>();
    }

    private float MinusQuarterOfNumber(float value)
    {
        return value - value * 0.25f;
    }

    private void TimeIsPassed(object state)
    {
        Debug.Log($"Рабочее время вышло");
        ReachPoint();
    }
}
