using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner 
{
    private CircleSpawnerConfig _config;
    private CircleFactory _circleFactory;

    public CircleSpawner(CircleFactory circleFactory, CircleSpawnerConfig config)
    {
        _config = config;
        _circleFactory = circleFactory;
    }

    public List<CircleMonobehavior> CreateCircles(TypeCircle typeCircle, int amount)
    {
        List<CircleMonobehavior> circles = new List<CircleMonobehavior>();
        System.Random random = new System.Random();
        for (int i = 0; i < amount; i++)
        {
            CircleMonobehavior circle = _circleFactory.Get(typeCircle);
            circle.transform.position = new Vector3(random.Next(0, _config.LimitX), 0, random.Next(0, _config.LimitZ));
            circles.Add(circle);
        }

        return circles;
    }
}
