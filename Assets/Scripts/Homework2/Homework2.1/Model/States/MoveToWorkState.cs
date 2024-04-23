using UnityEngine;

public class MoveToWorkState : MovementOrNotState
{
    public MoveToWorkState(BusinessCube businessCube, IStateSwitcher stateSwitcher) : base(businessCube, stateSwitcher)
    {
        _nameOfPoint = PointsOfInterestForBusinessCube.NamesOfPoint.Work;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"���� �� ������");
    }

    public override void Exit()
    {
        Debug.Log($"������ �� ������");
        base.Exit();        
    }

    public override void ReachPoint()
    {
        StateSwitcher.SwitchState<StayAtWorkState>();
    }
}
