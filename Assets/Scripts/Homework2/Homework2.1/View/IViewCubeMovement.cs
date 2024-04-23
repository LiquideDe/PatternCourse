using UnityEngine;

public interface IViewCubeMovement
{
    Transform Transform { get; }
    void SetPresenter(IPresenter presenter);
    void SetNewStrategy(MoveStrategy moveStrategy);

}
