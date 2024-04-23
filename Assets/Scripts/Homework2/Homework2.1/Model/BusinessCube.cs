using System;

public class BusinessCube
{
    public event Action StateWasChanged;

    private BusinessCubeStateMachine _stateMachine;
    public const float MaxSpeed = 0.8f;

    public float Speed { get; set; }

    public BusinessCube()
    {
        _stateMachine = new BusinessCubeStateMachine(this);
    }

    public void TellStateWasChanged()
    {
        StateWasChanged?.Invoke();
    }

    public void ReachPoint() => _stateMachine.ReachPoint();

    public PointsOfInterestForBusinessCube.NamesOfPoint GetNameOfPoint() => _stateMachine.GetNameOfPoint();
}
