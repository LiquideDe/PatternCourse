using System.Collections.Generic;
using System.Linq;

public class BusinessCubeStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public BusinessCubeStateMachine(BusinessCube cube)
    {
        _states = new List<IState>()
        {
            new StayAtHomeState(cube, this),
            new MoveToWorkState(cube, this),
            new StayAtWorkState(cube, this),
            new MoveToHomeState(cube, this)            
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void ReachPoint()
    {
        _currentState.ReachPoint();
    }

    public PointsOfInterestForBusinessCube.NamesOfPoint GetNameOfPoint()
    {
        return _currentState.NameOfPoint();
    }
}
