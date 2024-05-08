using Zenject;

public class CircleMediatorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInstance();
    }

    private void BindInstance()
    {
        Container.BindInterfacesAndSelfTo<CircleMediator>().AsSingle();
    }
}
