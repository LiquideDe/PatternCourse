using System;
using Zenject;

public class GameplayMediator : IDisposable, IGameplayMediator
{
    private DefeatPanel _defeatPanel;
    private Level _level;

    public GameplayMediator(Level level)
    {
        _level = level;        
        _level.Defeat += OnLevelDefeat;
    }

    [Inject]
    private void Construct(DefeatPanel defeatPanel)
    {
        _defeatPanel = defeatPanel;
        _defeatPanel.Initialize(this);

        /*
         * я пыталс€ забиндить обоих в инсталере, и у панели поражени€ указать через инжект, но посто€нно получал ошибку 
         * Unable to resolve type DefeatePanel while building object with type GameplayMediator. Ќичего другого не придумал, кроме как 
         * в самом медиаторе скинуть ссылку панели на себ€.
         * 
         * ƒа потом пон€л, что и правда лучше только, чтобы медиатор знал, о UI и просто подписывалс€, € так и сделал в следующем зан€тии. 
         * Ќо все же, есть ли возможность как то это обойти? „тобы два объекта знали друг о друге если это вдруг понадобитьс€?
         */
    }

    private void OnLevelDefeat() => _defeatPanel.Show();

    public void RestartLevel()
    {
        _defeatPanel.Hide();
        _level.Restart();
    }

    public void Dispose()
    {
        _level.Defeat -= OnLevelDefeat;
    }
}
