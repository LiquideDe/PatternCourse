using Zenject;

public class MediatorInstaller : MonoInstaller
{  
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Level>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameplayMediator>().AsSingle();        
    }
}
