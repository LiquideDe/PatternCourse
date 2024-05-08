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
         * ����� Zenject ��������, ��� Zenject Warning: It is bad practice to call Inject/Resolve/Instantiate before all the Installers have completed!
         * �� ��� ����� �� ������� UI ����� ��� ��������� �� ���������? � ��� ��������� �����?
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
