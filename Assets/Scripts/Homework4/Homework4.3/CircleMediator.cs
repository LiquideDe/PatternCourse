using System;

public class CircleMediator : IDisposable
{
    private CircleUI _circleUI;
    private InputCircleView _inputCircle;
    private CircleKeeper _circleKeeper;
    private SceneLoader _sceneLoader;

    public CircleMediator(InputCircleView inputCircle, CircleUI circleUI, CircleKeeper circleKeeper, SceneLoader sceneLoader)
    {
        _inputCircle = inputCircle;
        _circleUI = circleUI;
        _circleKeeper = circleKeeper;
        _sceneLoader = sceneLoader;
        Subscribe();
    }

    public void StartGame(int minCirclesOneColor, int maxCirclesOneColor) => _circleKeeper.CreatePlayingField(minCirclesOneColor, maxCirclesOneColor);
    
    public void ClickedOnCircle(CircleMonobehavior circle)
    {
        _circleKeeper.ClickedOnCircle(circle);
    }

    public void Dispose()
    {
        Unscribe();
    }

    public void ExitToMainMenu()
    {
        _sceneLoader.LoadMenu();
    }

    public void RestartLevel()
    {
        _circleUI.Hide();
        _circleKeeper.RestartLevel();
    }

    private void Subscribe()
    {
        _circleUI.RestartClicked += RestartLevel;
        _circleUI.ExitToMenuClicked += ExitToMainMenu;
        _inputCircle.ClickedOnCircle += ClickedOnCircle;
        _circleKeeper.VictoryCondition.GameWining += _circleUI.ShowWin;
        _circleKeeper.VictoryCondition.GameLoose += _circleUI.ShowLoose;
    }

    private void Unscribe()
    {
        _circleKeeper.VictoryCondition.GameWining -= _circleUI.ShowWin;
        _circleKeeper.VictoryCondition.GameLoose -= _circleUI.ShowLoose;
    }

}
