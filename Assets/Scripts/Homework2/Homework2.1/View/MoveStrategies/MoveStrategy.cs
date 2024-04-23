using UnityEngine;

public abstract class MoveStrategy
{
    protected Vector3 _pointToReach;
    protected Transform _cubeAtScene;
    protected float _speed;

    public MoveStrategy(Vector3 pointToReach, Transform cubeAtScene, float speed)
    {
        _pointToReach = pointToReach;
        _cubeAtScene = cubeAtScene;
        _speed = speed;
    }

    public abstract void Update();
}
