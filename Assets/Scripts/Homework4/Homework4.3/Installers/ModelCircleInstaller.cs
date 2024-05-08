using UnityEngine;
using Zenject;

public class ModelCircleInstaller : MonoInstaller
{
    [SerializeField] CircleSpawnerConfig _circleSpawnerConfig;
    public override void InstallBindings()
    {
        BindConfigs();
        BindInstance();
    }

    private void BindConfigs()
    {
        Container.Bind<CircleSpawnerConfig>().FromInstance(_circleSpawnerConfig).AsSingle();
    }

    private void BindInstance()
    {
        Container.Bind<CircleFactory>().AsSingle();
        Container.Bind<CircleSpawner>().AsSingle();
        Container.Bind<CircleKeeper>().AsSingle();
    }
}
