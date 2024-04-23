using UnityEngine;

public class MoveToAnywhere : MoveStrategy
{
    public MoveToAnywhere(Vector3 pointToReach, Transform cubeAtScene, float speed) : base(pointToReach, cubeAtScene, speed)
    {
    }

    public override void Update()
    {
        Vector3 direction = _pointToReach - _cubeAtScene.transform.position;
        direction.y = 0;
        _cubeAtScene.Translate(direction * _speed * Time.deltaTime);
    }

    public void ChangeSpeed(float speed)
    {
        _speed = speed;
    }

    public void ChangeDestination(Vector3 vector)
    {
        _pointToReach = vector;
    }
}
