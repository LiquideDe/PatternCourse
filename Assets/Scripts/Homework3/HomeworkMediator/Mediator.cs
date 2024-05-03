public class Mediator: IMediator, IMediatorInput
{
    private ViewPlayer _viewPlayer;
    private PlayerModel _playerModel;
    private InputView _inputView;

    public Mediator(InputView inputView, ViewPlayer viewPlayer, PlayerModel player)
    {
        _viewPlayer = viewPlayer;
        _inputView = inputView;
        _playerModel = player;

        _inputView.SetMediator(this);
        _viewPlayer.SetMediator(this);

        _playerModel.Dead += PlayerDead;
        _playerModel.HpWasChanged += UpdateHpText;
        _playerModel.LvlWasChanged += UpdateLvlText;

        _inputView.StartPlaying();

        UpdateHpText();
        UpdateLvlText();
    }

    public void LvlUp() => _playerModel.IncreaseLvl();

    public void DecreaseHp() => _playerModel.DecreaseHp();

    public void RestartLvl()
    {
        _playerModel.RestartLvl();
        _inputView.StartPlaying();
        _viewPlayer.HideRestartPanel();
    }

    public void Unscribe()
    {
        _playerModel.Dead -= PlayerDead;
        _playerModel.HpWasChanged -= UpdateHpText;
        _playerModel.LvlWasChanged -= UpdateLvlText;
    }

    private void PlayerDead() 
    {
        _viewPlayer.ShowRestartPanel();
        _inputView.StopPlaying();
    }        

    private void UpdateHpText() => _viewPlayer.UpdateTextHp(_playerModel.Hp);

    private void UpdateLvlText() => _viewPlayer.UpdateTextLvl(_playerModel.Lvl);

}
