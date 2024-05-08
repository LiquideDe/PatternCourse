using UnityEngine;
using Zenject;

public class DefeatPanelInstaller : MonoInstaller
{
    [SerializeField] private DefeatPanel _defeatPanelPrefab;
    [SerializeField] private Transform _canvas;
    
    public override void InstallBindings()
    {
        DefeatPanel defeatPanel = Container.InstantiatePrefabForComponent<DefeatPanel>(_defeatPanelPrefab, _canvas);
        Container.BindInterfacesAndSelfTo<DefeatPanel>().FromInstance(defeatPanel).AsSingle();
    }
}
