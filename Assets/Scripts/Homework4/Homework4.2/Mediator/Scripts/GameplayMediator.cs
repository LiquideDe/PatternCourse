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
         * � ������� ��������� ����� � ���������, � � ������ ��������� ������� ����� ������, �� ��������� ������� ������ 
         * Unable to resolve type DefeatePanel while building object with type GameplayMediator. ������ ������� �� ��������, ����� ��� 
         * � ����� ��������� ������� ������ ������ �� ����.
         * 
         * �� ����� �����, ��� � ������ ����� ������, ����� �������� ����, � UI � ������ ������������, � ��� � ������ � ��������� �������. 
         * �� ��� ��, ���� �� ����������� ��� �� ��� ������? ����� ��� ������� ����� ���� � ����� ���� ��� ����� ������������?
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
