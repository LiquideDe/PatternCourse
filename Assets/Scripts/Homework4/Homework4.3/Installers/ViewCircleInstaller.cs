using UnityEngine;
using Zenject;

public class ViewCircleInstaller : MonoInstaller
{
    [SerializeField] InputCircleView _inputCircleView;
    [SerializeField] Transform _canvasTransform;
    [SerializeField] CircleUI _circleUI;

    public override void InstallBindings()
    {
        BindInstance();
        /* 
         * Здесь Zenject ругается, что Zenject Warning: It is bad practice to call Inject/Resolve/Instantiate before all the Installers have completed!
         * Но мне нужно же создать UI блоки для медиатора до медиатора? А как правильно будет?
         */
    }

    private void BindInstance()
    {
        InputCircleView inputCircle = Container.InstantiatePrefabForComponent<InputCircleView>(_inputCircleView);
        Container.BindInterfacesAndSelfTo<InputCircleView>().FromInstance(inputCircle).AsSingle();

        CircleUI circleUI = Container.InstantiatePrefabForComponent<CircleUI>(_circleUI, _canvasTransform);
        Container.BindInterfacesAndSelfTo<CircleUI>().FromInstance(circleUI).AsSingle();
    }
}
