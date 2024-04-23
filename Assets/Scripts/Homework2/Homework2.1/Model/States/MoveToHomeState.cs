using UnityEngine;

public class MoveToHomeState : MovementOrNotState
{
    public MoveToHomeState(BusinessCube businessCube, IStateSwitcher stateSwitcher) : base(businessCube, stateSwitcher)
    {
        _nameOfPoint = PointsOfInterestForBusinessCube.NamesOfPoint.Home;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"Наконец-то домой");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void ReachPoint()
    {
        StateSwitcher.SwitchState<StayAtHomeState>();
    }
}
