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
        Debug.Log($"Идем на работу");
    }

    public override void Exit()
    {
        Debug.Log($"Пришли на работу");
        base.Exit();        
    }

    public override void ReachPoint()
    {
        StateSwitcher.SwitchState<StayAtWorkState>();
    }
}
