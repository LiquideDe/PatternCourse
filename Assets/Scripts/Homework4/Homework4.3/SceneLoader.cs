using UnityEngine;

public class SceneLoader
{
    private ZenjectSceneLoaderWrapper _zenjectSceneLoader;

    public SceneLoader(ZenjectSceneLoaderWrapper zenjectSceneLoader)
    {
        _zenjectSceneLoader = zenjectSceneLoader;
    }

    public void LoadGame(VictoryCondition victoryCondition)
    {
        //Поставить енам вместо 1
        _zenjectSceneLoader.Load((int)SceneLevels.Gameplay, container =>
        {
            container.BindInstance(victoryCondition).AsSingle();
        });
    }

    public void LoadMenu()
    {
        _zenjectSceneLoader.Load((int)SceneLevels.MainMenu);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
