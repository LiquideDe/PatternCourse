using UnityEngine;
using Zenject;

public class CircleFactory
{
    private LoadCircleConfigs _circleConfigs;
    private DiContainer _diContainer;

    public CircleFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
        _circleConfigs = new LoadCircleConfigs();
    }

    public CircleMonobehavior Get(TypeCircle typeCircle)
    {
        CircleConfig circleConfig = _circleConfigs.Get(typeCircle);
        CircleMonobehavior instance = _diContainer.InstantiatePrefabForComponent<CircleMonobehavior>(circleConfig.CirclePrefab);
        instance.Initialize(circleConfig);
        return instance;
    }
}
