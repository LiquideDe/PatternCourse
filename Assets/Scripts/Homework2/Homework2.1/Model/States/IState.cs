public interface IState
{
    void Enter();
    void Exit();
    void ReachPoint();
    PointsOfInterestForBusinessCube.NamesOfPoint NameOfPoint();
}
