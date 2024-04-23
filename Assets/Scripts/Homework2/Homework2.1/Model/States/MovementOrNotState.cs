public abstract class MovementOrNotState : IState
{
    protected readonly BusinessCube _businessCube;
    protected PointsOfInterestForBusinessCube.NamesOfPoint _nameOfPoint;
    protected readonly IStateSwitcher StateSwitcher;

    public MovementOrNotState(BusinessCube businessCube, IStateSwitcher stateSwitcher)
    {
        _businessCube = businessCube;
        StateSwitcher = stateSwitcher;
    }
    public virtual void Enter()
    {
        _businessCube.TellStateWasChanged();
    }

    public virtual void Exit()
    {
        
    }

    public PointsOfInterestForBusinessCube.NamesOfPoint NameOfPoint()
    {
        return _nameOfPoint;
    }

    public abstract void ReachPoint();
}
