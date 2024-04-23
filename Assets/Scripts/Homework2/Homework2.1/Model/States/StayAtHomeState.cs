using System;
using UnityEngine;

public class StayAtHomeState : MovementOrNotState
{
    public StayAtHomeState(BusinessCube businessCube, IStateSwitcher stateSwitcher) : base(businessCube, stateSwitcher)
    {
        _nameOfPoint = PointsOfInterestForBusinessCube.NamesOfPoint.None;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"Можно и отдохнуть");
        _businessCube.Speed = BusinessCube.MaxSpeed;
        var t1 = new System.Threading.Timer(TimeIsPassed, null, TimeSpan.FromSeconds(2), TimeSpan.Zero);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void ReachPoint()
    {
        StateSwitcher.SwitchState<MoveToWorkState>();
    }

    private void TimeIsPassed(object state)
    {
        Debug.Log($"Время сна вышло");
        ReachPoint();
    }
}
