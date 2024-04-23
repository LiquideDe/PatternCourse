using UnityEngine;

public class StayAtPosition : MoveStrategy
{
    public StayAtPosition(Vector3 pointToReach, Transform cubeAtScene, float speed) : base(pointToReach, cubeAtScene, speed)
    {
    }

    public override void Update()
    {
        
    }
}
