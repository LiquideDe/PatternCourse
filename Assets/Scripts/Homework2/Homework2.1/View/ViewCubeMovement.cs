using UnityEngine;

public class ViewCubeMovement : MonoBehaviour, IViewCubeMovement
{
    private MoveStrategy _moveStrategy;
    private bool _isStrategySet;
    private IPresenter _presenter;

    public Transform Transform => transform;

    void Update()
    {
        if (_isStrategySet)
            _moveStrategy.Update();
    }

    public void SetPresenter(IPresenter presenter)
    {
        _presenter = presenter;
    }

    public void SetNewStrategy(MoveStrategy moveStrategy)
    {
        _moveStrategy = moveStrategy;
        _isStrategySet = true;
    }

    public void ReachPoint()
    {
        _presenter.ReachPoint();
    }
}
