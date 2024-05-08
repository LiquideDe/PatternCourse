using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainCircleMenu : MonoBehaviour
{
    [SerializeField] Button _buttonDestroyAllStrategy, _buttonDestroyOneColorStrategy, _buttonExit;
    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    private void OnEnable()
    {
        _buttonDestroyAllStrategy.onClick.AddListener(StartDestroyAllLevel);
        _buttonDestroyOneColorStrategy.onClick.AddListener(StartDestroyOneColorLevel);
        _buttonExit.onClick.AddListener(ExitFromGame);
    }

    private void OnDisable()
    {
        _buttonDestroyAllStrategy.onClick.RemoveAllListeners();
        _buttonDestroyOneColorStrategy.onClick.RemoveAllListeners();
        _buttonExit.onClick.RemoveAllListeners();
    }

    private void StartDestroyAllLevel()
    {
        _sceneLoader.LoadGame(new DestroyAllCircles());
    }

    private void StartDestroyOneColorLevel()
    {
        _sceneLoader.LoadGame(new DestroyOnlyOneColor());
    }

    private void ExitFromGame()
    {
        _sceneLoader.Exit();
    }
}
